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
	public						StopWatch			watchScript;

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
		int minutes = scores[0] / 60;
		int seconds = scores[0] % 60;
		catacombsScore.text = $"{minutes}:{seconds}mins";
		minutes = scores[1] / 60;
		seconds = scores[1] % 60;
		asylumScore.text = $"{minutes}:{seconds}mins";
	}
	//add options menu to quit and change volume
	
	public void SetAndInitWatch(GameObject watch)
	{
		stopWatch = watch;
		InitTimer?.Invoke();
	}

	public void StartTimerdw()
	{
		Debug.Log("timer called");
		StartTimer?.Invoke();
	}
}
