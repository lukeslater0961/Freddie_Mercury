using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private GameObject xrPlayer;
	[SerializeField] private Transform	spawnPos;
	private GameObject _playerInstance;

	public void InstantiatePlayer()
	{
		_playerInstance = Instantiate(xrPlayer, spawnPos.position , Quaternion.identity);
	}

    public void ResetPlayer(Transform spawnPos)
    {
        if (_playerInstance != null)
            _playerInstance.transform.position = spawnPos.position;
    }
}
