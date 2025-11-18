using UnityEngine;
using System.Collections;

public class AsylumInitializer : MonoBehaviour, ILevelInitializer
{
	[SerializeField]	private Transform			spawnPos;

	void Awake()
	{
		LevelInitializerService.current = this;
	}

	public IEnumerator InitializeLevel()
	{
		Debug.Log("Asylum level Initializer => Initalizing level");
		yield return InstanceObjects();
		//enter level 1 state (room logic handle here)
		//UiManager.instance.StartTimerdw(); call this when game is ready
	}

	private IEnumerator InstanceObjects(){
		//instance room state manager
		PlayerManager.instance.DestroyInstance();
		PlayerManager.instance.InstantiatePlayer(spawnPos);
		yield break;
	}
}
