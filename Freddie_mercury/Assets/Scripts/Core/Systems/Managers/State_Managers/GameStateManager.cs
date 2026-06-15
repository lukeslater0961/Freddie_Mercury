sing UnityEngine;
using System.Collections;
using System;

public class GameStateManager : Singleton<GameStateManager> 
{
	public static BootState bootState = new BootState();
	public static MainMenuState mainMenuState = new MainMenuState();
	public static LevelState levelState	= new LevelState();

	private GameBaseState currentState = null;

	public static event Action InLevelState;

	public void InvokeLevelState()
	{
		InLevelState?.Invoke();
	}

	public void SwitchState(GameBaseState state)
	{
		if (currentState != null)
			StartCoroutine(currentState.QuitState(this));
		currentState = state;
		StartCoroutine(currentState.EnterState(this));
	}

	public void RunCoroutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }
}
