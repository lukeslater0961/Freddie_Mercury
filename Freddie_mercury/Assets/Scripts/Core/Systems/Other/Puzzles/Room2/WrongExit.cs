using UnityEngine;
using System;

public class WrongExit : MonoBehaviour
{
	public static event Action OnWrongExitTaken;

	[SerializeField]	Transform spawnPos;
	
	void OnTriggerEnter(Collider Enter)
	{
		PlayerManager.instance.ResetPlayer(spawnPos);
		OnWrongExitTaken?.Invoke();
	}


	[ContextMenu("wrong exit")]
	void UseExit()
	{
		PlayerManager.instance.ResetPlayer(spawnPos);
		OnWrongExitTaken?.Invoke();
	}
}
