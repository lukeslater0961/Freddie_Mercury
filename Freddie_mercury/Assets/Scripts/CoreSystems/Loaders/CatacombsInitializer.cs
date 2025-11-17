using UnityEngine;

public class CatacombsInitializer : MonoBehaviour
{
	[SerializeField] GameObject xrPlayer;
	[SerializeField] Transform	spawnPos; 

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
		Instantiate(xrPlayer, spawnPos.position , Quaternion.identity);
	}
}
