using UnityEngine;

public class AsylumInitializer : MonoBehaviour
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
		Debug.Log("ASylum level Initializer => initalizing level");
	}
}
