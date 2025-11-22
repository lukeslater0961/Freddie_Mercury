using UnityEngine;
using System;
using System.Collections;

public class RoomBaseStateManager: MonoBehaviour
{
	public static event Action OnRoomCompleted;
	public static event Action<int> ReduceTime;

	public void RunCoroutine(IEnumerator routine)
    {
        StartCoroutine(routine);
    }

	public void RaiseRoomCompleted()
	{
		OnRoomCompleted?.Invoke();
	}

	public void ApplyTimePenalty()
	{
		ReduceTime?.Invoke(10);
	}
}
