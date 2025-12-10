using UnityEngine;
using System.Collections;
public class Portal : MonoBehaviour
{
	private enum levelId{
		level1,
		level2
	};

	[SerializeField]	private LayerMask	layerMask = 3;
	[SerializeField]	private levelId		level;

	[ContextMenu("load asylum")]
	void LoadAsylum(){
		SceneLoader.instance.StartCoroutine(SceneLoader.instance.EnterLevel(2));	
	}

	[ContextMenu("load catacombs")]
	void LoadCatacombs(){
		SceneLoader.instance.StartCoroutine(SceneLoader.instance.EnterLevel(3));	
	}

	void OnTriggerEnter(Collider other)
	{
		if ((layerMask & (1 << other.gameObject.layer)) == 0) return;
		switch (level)
		{
			case levelId.level1:
				SceneLoader.instance.StartCoroutine(SceneLoader.instance.EnterLevel(3));	
				break;
			case levelId.level2:
				SceneLoader.instance.StartCoroutine(SceneLoader.instance.EnterLevel(2));	
				break;
			default:
				Debug.Log("No levelId set");
				break;
		}
	}
}
