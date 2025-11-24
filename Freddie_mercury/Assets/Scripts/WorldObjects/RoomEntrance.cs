using UnityEngine;
using System;

public class RoomEntrance : MonoBehaviour
{
	private RoomManager roomManager;
	public static event Action OnEntranceExited;

	void Awake()
	{
		roomManager = GameObject.FindFirstObjectByType<RoomManager>();
	}

	void OnTriggerEnter(Collider other)
	{
		roomManager.HidePreviousRoom();
		OnEntranceExited?.Invoke();
		gameObject.SetActive(false);
	}
}
