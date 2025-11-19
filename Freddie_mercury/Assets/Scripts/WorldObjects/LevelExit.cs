using UnityEngine;
using System;

public class LevelExit : MonoBehaviour
{
	public static event Action OnLevelExit;

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Level => next level");
		OnLevelExit?.Invoke();
	}
}
