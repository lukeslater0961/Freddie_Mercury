using UnityEngine;

public class MainMenuInitializer : MonoBehaviour
{
	[SerializeField] GameObject xrPlayer;
	[SerializeField] Transform spawnPos; 

	
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
		UiManager.instance.ToggleMainMenu();
	}
}
