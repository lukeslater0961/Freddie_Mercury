using UnityEngine;
using System.Collections;
using TMPro;

public class UiManager : Singleton<UiManager> 
{
	[SerializeField]	GameObject			MainMenu;
	[SerializeField]	TextMeshProUGUI 	asylumScore;
	[SerializeField]	TextMeshProUGUI		catacombsScore;

	public void InitUi()
	{
		Debug.Log("UiManager => Initializing UI");
		MainMenu.SetActive(false);
	}

	public void ToggleMainMenu()
	{
		Debug.Log("UiManager => Toggling MainMenu");
		MainMenu.SetActive(!MainMenu.activeSelf);
	}

	public void SetStatsBoard(int[] scores)
	{
		Debug.Log("UiManager => Setting scores to text");
		asylumScore.text = $"{scores[0]}mins";
		catacombsScore.text = $"{scores[1]}mins";
	}

	//add options menu to quit and change volume
}
