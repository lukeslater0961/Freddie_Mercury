using UnityEngine;

public class MainMenuInitializer : MonoBehaviour
{
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
		PlayerManager.instance.InstantiatePlayer();
		SaveManager.instance.LoadScores();
		UiManager.instance.SetStatsBoard(SaveManager.instance.scores);
		UiManager.instance.ToggleMainMenu();
	}
}
