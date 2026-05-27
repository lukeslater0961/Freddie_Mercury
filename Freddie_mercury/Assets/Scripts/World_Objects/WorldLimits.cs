using UnityEngine;
using System;

public class WorldLimits : MonoBehaviour
{
	public static event Action OnHit;

	[SerializeField] private LayerMask _playerLayerMask;
	[SerializeField] Transform	spawnPos;

	void OnTriggerEnter(Collider other)
	{
		int layer = other.gameObject.layer;

		if ((_playerLayerMask.value & (1 << layer)) != 0)
		{
			PlayerManager.instance.ResetPlayer(spawnPos);
			OnHit?.Invoke();
		}
		else
			other.GetComponent<ObjectRespawn>().Respawn();
	}
}
