using System.Collections;
using UnityEngine;
using System;
using TMPro;

public class UiManager : Singleton<UiManager> 
{
	public static event Action InitTimer;
	public static event Action StartTimer;

	[SerializeField]	GameObject					MainMenu;
	
	[SerializeField]	private TextMeshProUGUI 	asylumScore;
	[SerializeField]	private TextMeshProUGUI		catacombsScore;
	public						GameObject			stopWatch;

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
	
	public void SetAndInitWatch(GameObject watch)
	{
		stopWatch = watch;
		InitTimer?.Invoke();
	}

	public void StartTimerdw()
	{
		Debug.Log("tiner called");
		StartTimer?.Invoke();
	}
}
