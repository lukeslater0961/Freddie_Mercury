using UnityEngine;
using System.Collections;

public class AsylumInitializer : MonoBehaviour, ILevelInitializer
{
	[SerializeField]	private Transform			spawnPos;

	[SerializeField]	private AsylumStateManager	stateManagerPrefab;
	[SerializeField]	private AsylumStateManager	stateManagerInstance;

	[SerializeField]	private RoomManager			roomManagerPrefab;
	[SerializeField]	private RoomManager			roomManagerInstance;

	void Awake()
	{
		LevelInitializerService.current = this;
		Exit.OnLevelFinished += QuitLevel;
	}

	public IEnumerator InitializeLevel()
	{
		Debug.Log("Asylum level Initializer => Initalizing level");
		yield return InstanceObjects();

		//enter level 1 state (room logic handle here)
	}

	private IEnumerator InstanceObjects()
	{
		stateManagerInstance = Instantiate(stateManagerPrefab);
		roomManagerInstance = Instantiate(roomManagerPrefab);

		PlayerManager.instance.DestroyInstance();
		PlayerManager.instance.InstantiatePlayer(spawnPos);

		stateManagerInstance.SwitchState(AsylumStateManager.asylum1State);
		yield break;
	}

	void QuitLevel()
	{
		Debug.Log("Asylum Initializer => quitting level");
		Exit.OnLevelFinished -= QuitLevel;
		PlayerManager.instance.DestroyInstance();
		SceneLoader.instance.StartCoroutine(SceneLoader.instance.EnterMainMenu());
	}
}
