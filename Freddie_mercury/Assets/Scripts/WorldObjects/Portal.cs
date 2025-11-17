using UnityEngine;

public class Portal : MonoBehaviour
{
	private enum levelId{
		level1,
		level2
	};

	[SerializeField] private LayerMask layerMask = 3;

	[SerializeField]private levelId level;

	void OnTriggerEnter(Collider other)
	{
		if ((layerMask & (1 << other.gameObject.layer)) == 0) return;
		switch (level)
		{
			case levelId.level1:
				SceneLoader.instance.LoadScene(3);
				break;
			case levelId.level2:
				SceneLoader.instance.LoadScene(2);
				break;
			default:
				Debug.Log("No levelId set");
				break;
		}
	}
}
