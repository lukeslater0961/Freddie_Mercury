using UnityEngine;
using System;

public class Exit : MonoBehaviour
{
	public static event Action OnLevelFinished;

	[ContextMenu("exit level")]
	void ExitLevel()
	{
		Debug.Log("Exit => Going back to Menu");
		OnLevelFinished?.Invoke();
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Exit => Going back to Menu");
		OnLevelFinished?.Invoke();
	}
}
