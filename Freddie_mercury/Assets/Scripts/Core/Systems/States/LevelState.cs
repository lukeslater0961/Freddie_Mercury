using UnityEngine;
using System;
using System.Collections;

public class LevelState : GameBaseState
{
	public static event Action InitializeLevel;

	public override IEnumerator EnterState(GameStateManager manager)
	{
		Debug.Log("Entered Level state");
		InitializeLevel?.Invoke();
		yield break;
	}

	public override IEnumerator QuitState(GameStateManager manager)
	{
		yield break;
	}
}
