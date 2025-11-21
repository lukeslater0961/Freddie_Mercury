using UnityEngine;

public class RoomEntrance : MonoBehaviour
{
	private RoomManager roomManager;

	void Awake()
	{
		roomManager = GameObject.FindFirstObjectByType<RoomManager>();
	}

	void OnTriggerEnter(Collider other)
	{
		roomManager.HidePreviousRoom();
		gameObject.SetActive(false);
	}
}
