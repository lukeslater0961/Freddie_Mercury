using UnityEngine;
using System.Collections;

public class GameStateManager : Singleton<GameStateManager> 
{
	public static BootState bootState = new BootState();
	public static MainMenuState mainMenuState = new MainMenuState();

	private GameBaseState currentState = null;

	public void SwitchState(GameBaseState state)
	{
		currentState = state;
		StartCoroutine(currentState.EnterState(this));
	}

	public void RunCoroutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }
}
