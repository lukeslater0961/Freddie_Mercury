using UnityEngine;
using System.Collections;

public class AsylumInitializer : MonoBehaviour, ILevelInitializer
{
	[SerializeField]	private Transform			spawnPos;
	[SerializeField]	private AsylumStateManager	stateManagerPrefab;
	[SerializeField]	private AsylumStateManager	stateManagerInstance;

	void Awake()
	{
		LevelInitializerService.current = this;
		Exit.OnLevelFinished += QuitLevel;
	}

	public IEnumerator InitializeLevel()
	{
		Debug.Log("Asylum level Initializer => Initalizing level");
		yield return InstanceObjects();
		stateManagerInstance.SwitchState(AsylumStateManager.asylum1State);

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
		Debug.Log("Asylum Initializer => quitting level");
		Exit.OnLevelFinished -= QuitLevel;
		PlayerManager.instance.DestroyInstance();
		SceneLoader.instance.StartCoroutine(SceneLoader.instance.EnterMainMenu());
	}
}
