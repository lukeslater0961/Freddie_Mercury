using UnityEngine;
using System;
using System.Collections;

public class LevelState : GameBaseState
{

	public override IEnumerator EnterState(GameStateManager manager)
	{
		Debug.Log("Entered Level state");
		if (LevelInitializerService.current != null)
			yield return LevelInitializerService.current.InitializeLevel();
	}

	public override IEnumerator QuitState(GameStateManager manager)
	{
		yield break;
	}
}
