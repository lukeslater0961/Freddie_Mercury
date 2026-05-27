using UnityEngine;

public class ObjectRespawn : MonoBehaviour
{
	[SerializeField] Vector3 objectPosition;

	void Start()
	{
		objectPosition = transform.position;
	}
	
	public void Respawn()
	{
		transform.position = objectPosition;
	}
}
