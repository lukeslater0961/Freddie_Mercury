using UnityEngine;

public class MainMenuInitializer : MonoBehaviour
{
	[SerializeField] private Transform spawnPos;

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
		PlayerManager.instance.InstantiatePlayer(spawnPos);

		SaveManager.instance.LoadScores();
		UiManager.instance.SetStatsBoard(SaveManager.instance.scores);
		UiManager.instance.ToggleMainMenu();
	}
}
