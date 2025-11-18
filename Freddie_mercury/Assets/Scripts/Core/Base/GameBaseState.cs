using UnityEngine;
using System.Collections;

public abstract class GameBaseState
{
	public abstract IEnumerator EnterState(GameStateManager manager);
	public abstract IEnumerator QuitState(GameStateManager manager);
}
