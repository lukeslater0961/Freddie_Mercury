using UnityEngine;

public class CatacombsInitializer : MonoBehaviour
{
	[SerializeField] private Transform			spawnPos; 

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
		Debug.Log("Catacombs level Initializer => Initalizing level");
		PlayerManager.instance.DestroyInstance();
		PlayerManager.instance.InstantiatePlayer(spawnPos);
	}
}
