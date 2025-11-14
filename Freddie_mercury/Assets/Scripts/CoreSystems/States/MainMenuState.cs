using UnityEngine;
using System;
using System.Collections;

public class MainMenuState : GameBaseState
{
	public static event Action InitializeMainMenu;

	public override IEnumerator EnterState(GameStateManager manager)
	{
		Debug.Log("Entered Main Menu state");
		InitializeMainMenu?.Invoke();
		yield break;
	}
}
