using UnityEngine;

public class RoomManager : MonoBehaviour
{
	[SerializeField]	Transform[] roomTransforms;
	[SerializeField]	GameObject[] roomPrefabs;

	private GameObject[] roomInstances;
	private int			 currentRoom;

	void Awake(){Init();}

	void Init()
	{
		Debug.Log($"RoomManager =>  Initializing");

		currentRoom = 0;
		roomInstances = new GameObject[roomPrefabs.Length];

		if (LevelInitializerService.current is AsylumInitializer)
			AsylumStateManager.OnRoomCompleted += SetActiveRoom;
		else  if (LevelInitializerService.current is CatacombsInitializer)
			CatacombsStateManager.OnRoomCompleted += SetActiveRoom;

		InstantiateRooms();
	}
	
	public void InstantiateRooms()
	{
		for (int i = 0; i < roomPrefabs.Length; i++)
		{
			roomInstances[i] = Instantiate(roomPrefabs[i], roomTransforms[i]);
			if (i != 0)
				roomInstances[i].SetActive(false);
		}
	}

	public void SetActiveRoom()
	{
		Debug.Log("RoomManager => Setting next room active");
		currentRoom += 1;
		roomInstances[currentRoom].SetActive(true);
	}
	
	public void HidePreviousRoom()
	{
		roomInstances[--currentRoom].SetActive(false);
	}
}
