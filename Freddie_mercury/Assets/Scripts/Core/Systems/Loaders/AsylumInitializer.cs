using UnityEngine;
using System.Collections;

public class AsylumInitializer : MonoBehaviour
{
	[SerializeField]	private Transform			spawnPos;

	void Awake()
	{
		LevelState.InitializeLevel +=  InitializeLevel;
	}

	void OnDestroy()
	{
		LevelState.InitializeLevel -=  InitializeLevel;
	}

	void InitializeLevel()
	{
		StartCoroutine(Initalizing());
	}

	private IEnumerator Initalizing(){
		Debug.Log("ASylum level Initializer => Initalizing level");
		PlayerManager.instance.DestroyInstance();
		PlayerManager.instance.InstantiatePlayer(spawnPos);
		yield return new WaitForSeconds(1);
		//UiManager.instance.StartTimerdw(); call this when game is ready
	}
}
