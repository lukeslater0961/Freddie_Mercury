using UnityEngine;
using System;

public class RoomEntrance : MonoBehaviour
{
	private RoomManager roomManager;
	public static event Action OnEntranceExited;
	[SerializeField]	GameObject Door;

	void Awake()
	{
		roomManager = GameObject.FindFirstObjectByType<RoomManager>();
	}

	void OnTriggerEnter(Collider other)
	{
		roomManager.HidePreviousRoom();
		OnEntranceExited?.Invoke();
		Door.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		gameObject.SetActive(false);
	}
}
