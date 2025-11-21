using System.Collections;
using UnityEngine;
using System;

public class CatacombsStateManager : MonoBehaviour 
{
	public static Catacombs1State catacombs1State = new Catacombs1State();
	public static Catacombs2State catacombs2State = new Catacombs2State();
	public static Catacombs3State catacombs3State = new Catacombs3State();

	private LevelBaseState<CatacombsStateManager> currentState = null;

	public static event Action OnRoomCompleted;
	public static event Action<int> ReduceTime;

	public void SwitchState(LevelBaseState<CatacombsStateManager> state)
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
