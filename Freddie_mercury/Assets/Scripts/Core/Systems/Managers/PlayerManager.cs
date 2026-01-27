using UnityEngine;
using Unity.XR.CoreUtils;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private	GameObject xrPlayer;
	public						XROrigin   xrOrigin;
	public						GameObject _playerInstance;

	public void InstantiatePlayer(Transform spawnPos)
	{
		Debug.Log("PlayerManager => instantiating player...");
		_playerInstance = Instantiate(xrPlayer, spawnPos.position , Quaternion.identity);
		xrOrigin = _playerInstance.GetComponentInChildren<XROrigin>();
	}

	public void DestroyInstance()
	{
		Destroy(_playerInstance);
		_playerInstance = null;
		xrOrigin = null;
	}

	public void ResetPlayer(Transform newPos)
	{
		Vector3 cameraOffset = xrOrigin.Camera.transform.position - xrOrigin.transform.position;
        xrOrigin.transform.position = newPos.position - cameraOffset;
	}
}

