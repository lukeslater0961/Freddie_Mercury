using UnityEngine;

public class MainMenuInitializer : MonoBehaviour
{
	[SerializeField] GameObject xrPlayer;
	[SerializeField] Transform	spawnPos; 

	void Awake()
	{
		MainMenuState.InitializeMainMenu +=  InitializeMainMenu;
	}

	void OnDestroy()
	{
		MainMenuState.InitializeMainMenu -=  InitializeMainMenu;
	}

	void InitializeMainMenu()
	{
		Instantiate(xrPlayer, spawnPos.position , Quaternion.identity);
		SaveManager.instance.LoadScores();
		UiManager.instance.SetStatsBoard(SaveManager.instance.scores);
		UiManager.instance.ToggleMainMenu();
	}
}
