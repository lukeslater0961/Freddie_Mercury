using UnityEngine;
using System.Collections;

public class CatacombsInitializer : MonoBehaviour, ILevelInitializer
{
	[SerializeField]	private Transform			spawnPos;

	void Awake()
	{
		LevelInitializerService.current = this;
	}

	public IEnumerator InitializeLevel()
	{
		Debug.Log("Catacombs level Initializer => Initalizing level");
		yield return Initalizing();
	}

	private IEnumerator Initalizing(){
		PlayerManager.instance.DestroyInstance();
		PlayerManager.instance.InstantiatePlayer(spawnPos);
		//yield return new WaitForSeconds(1);
		//UiManager.instance.StartTimerdw(); call this when game is ready
		yield break;
	}

}
