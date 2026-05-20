using UnityEngine;
using System;

public class WorldLimits : MonoBehaviour
{
	public static event Action OnHit;
	[SerializeField] Transform	spawnPos;
	
	void OnTriggerEnter(Collider other)
	{
		PlayerManager.instance.ResetPlayer(spawnPos);
		OnHit?.Invoke();
	}
}
