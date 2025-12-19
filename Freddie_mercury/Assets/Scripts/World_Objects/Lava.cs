using UnityEngine;

public class Lava : MonoBehaviour
{
	[SerializeField] Transform	spawnPos;

	void OnTriggerEnter(Collider other)
	{
		PlayerManager.instance.ResetPlayer(spawnPos);
	}
}
