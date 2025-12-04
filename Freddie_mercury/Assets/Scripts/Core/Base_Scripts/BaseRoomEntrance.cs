using UnityEngine;
using System;

public abstract class BaseRoomEntrance : MonoBehaviour
{
	public static event Action OnEntranceExited;
	private RoomManager roomManager;

	public abstract void RoomEntered();

	protected virtual void Awake()
	{
		roomManager = GameObject.FindFirstObjectByType<RoomManager>();
	}

	protected virtual void OnTriggerEnter(Collider other)
	{
		Debug.Log($"room entrance triggered by {other.gameObject.name}");
		RoomEntered();
		roomManager.HidePreviousRoom();
		OnEntranceExited?.Invoke();
	}
}
