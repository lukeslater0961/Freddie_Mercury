using UnityEngine;

public class UiManager : Singleton<UiManager> 
{
	[SerializeField]	GameObject	MainMenu;

	public void InitUi()
	{
		MainMenu.SetActive(false);
	}

	public void ToggleMainMenu()
	{
		MainMenu.SetActive(!MainMenu.activeSelf);
	}

	//add options menu to quit and change volume
}
