using UnityEngine;
using System.Collections;

public class CatacombsInitializer : MonoBehaviour, ILevelInitializer
{
	[SerializeField]	private Transform			spawnPos;

	[SerializeField]	private CatacombsStateManager	stateManagerPrefab;
	[SerializeField]	private CatacombsStateManager	stateManagerInstance;

	[SerializeField]	private CatacombsRoomManager			roomManagerPrefab;
	[SerializeField]	private CatacombsRoomManager			roomManagerInstance;

	void Awake()
	{
		LevelInitializerService.current = this;
		Exit.OnLevelFinished += QuitLevel;
	}

	public IEnumerator InitializeLevel()
	{
		Debug.Log("Catacombs level Initializer => Initalizing level");
		yield return InstanceObjects();
		//enter level 1 state (room logic handle here)
	}

	private IEnumerator InstanceObjects(){
		stateManagerInstance = Instantiate(stateManagerPrefab);
		roomManagerInstance = Instantiate(roomManagerPrefab);

		PlayerManager.instance.DestroyInstance();
		PlayerManager.instance.InstantiatePlayer(spawnPos);

		stateManagerInstance.SwitchState(CatacombsStateManager.catacombsEntranceState);
		yield break;
	}

	void QuitLevel()
	{
		Debug.Log("Catacombs Initializer => quitting level");
		Exit.OnLevelFinished -= QuitLevel;
		PlayerManager.instance.DestroyInstance();
		SceneLoader.instance.StartCoroutine(SceneLoader.instance.EnterMainMenu());
	}
}
