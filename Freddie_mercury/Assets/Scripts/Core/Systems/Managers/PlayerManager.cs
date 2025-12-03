using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private	GameObject xrPlayer;
	public						GameObject _playerInstance;

	public void InstantiatePlayer(Transform spawnPos)
	{
		Debug.Log("PlayerManager => instantiating player...");
		_playerInstance = Instantiate(xrPlayer, spawnPos.position , Quaternion.identity);
	}

	public void DestroyInstance()
	{
		Destroy(_playerInstance);
		_playerInstance = null;
	}

	public void ResetPlayer(Transform newPos)
	{
		_playerInstance.transform.position = newPos.position;
	}
}

