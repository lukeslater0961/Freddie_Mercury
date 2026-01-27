using UnityEngine;
using System;

public class Lava : MonoBehaviour
{
	public static event Action OnHit;
	[SerializeField] Transform	spawnPos;
	
	void OnTriggerEnter(Collider other)
	{
		PlayerManager.instance.ResetPlayer(spawnPos);
		OnHit?.Invoke();
	}
}
