using UnityEngine;

public class RoomManager : MonoBehaviour
{
	[SerializeField] protected  Transform[]	 roomTransforms;
	[SerializeField] protected	GameObject[] roomPrefabs;

	[SerializeField]private GameObject[] roomInstances;
	private int			 currentRoom;

	void Awake(){Init();}

	//void Start(){Init();}

	void OnDestroy()
	{
		CatacombsStateManager.OnRoomCompleted -= SetActiveRoom;
	}

	void Init()
	{
		Debug.Log($"RoomManager =>  Initializing");

		currentRoom = 0;
		roomInstances = new GameObject[roomPrefabs.Length];
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
		Debug.Log($"SetActiveRoom called | currentRoom BEFORE increment: {currentRoom}");
		currentRoom += 1;
		Debug.Log($"currentRoom AFTER increment: {currentRoom}");
		roomInstances[currentRoom].SetActive(true);
	}

	public void HidePreviousRoom()
	{
		int previousRoom = currentRoom - 1;
		if (previousRoom >= 0 && previousRoom < roomInstances.Length)
			roomInstances[previousRoom].SetActive(false);	
	}
}
