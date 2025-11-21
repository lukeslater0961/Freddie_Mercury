using System.Collections;
using UnityEngine;
using System;

public class AsylumStateManager : MonoBehaviour 
{
	public static Asylum1State asylum1State = new Asylum1State();
	public static Asylum2State asylum2State = new Asylum2State();
	public static Asylum3State asylum3State = new Asylum3State();

	private LevelBaseState<AsylumStateManager> currentState = null;

	public static event Action OnRoomCompleted;
	public static event Action<int> ReduceTime;

	public void SwitchState(LevelBaseState<AsylumStateManager> state)
	{
		currentState = state;
		currentState.EnterState(this);
	}

	public void RunCoroutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }

	[ContextMenu("LoadNextRoom")]
	public void RaiseRoomCompleted()
	{
		OnRoomCompleted?.Invoke();
	}

	[ContextMenu("Apply time Penalty")]
	public void ApplyTimePenalty()
	{
		ReduceTime?.Invoke(10);
	}
}
