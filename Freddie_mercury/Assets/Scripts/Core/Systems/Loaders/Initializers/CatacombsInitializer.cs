using UnityEngine;
using System.Collections;

public class CatacombsInitializer : MonoBehaviour, ILevelInitializer
{
	[SerializeField]	private Transform			spawnPos;
	[SerializeField]	private CatacombsStateManager	stateManagerPrefab;
	[SerializeField]	private CatacombsStateManager	stateManagerInstance;

	void Awake()
	{
		LevelInitializerService.current = this;
		Exit.OnLevelFinished += QuitLevel;
	}

	public IEnumerator InitializeLevel()
	{
		Debug.Log("Catacombs level Initializer => Initalizing level");
		yield return InstanceObjects();
		stateManagerInstance.SwitchState(CatacombsStateManager.catacombs1State);
		//enter level 1 state (room logic handle here)
	}

	private IEnumerator InstanceObjects(){
		stateManagerInstance = Instantiate(stateManagerPrefab);
		PlayerManager.instance.DestroyInstance();
		PlayerManager.instance.InstantiatePlayer(spawnPos);
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
