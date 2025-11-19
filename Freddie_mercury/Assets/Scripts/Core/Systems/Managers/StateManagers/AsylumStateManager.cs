using UnityEngine;
using System.Collections;

public class AsylumStateManager : MonoBehaviour 
{
	public static Asylum1State asylum1State = new Asylum1State();
	public static Asylum2State asylum2State = new Asylum2State();
	public static Asylum3State asylum3State = new Asylum3State();
	private LevelBaseState<AsylumStateManager> currentState = null;

	public void SwitchState(LevelBaseState<AsylumStateManager> state)
	{
		currentState = state;
		currentState.EnterState(this);
	}

	public void RunCoroutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }
}
