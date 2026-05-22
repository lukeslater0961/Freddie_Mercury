using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
	[SerializeField]	private LayerMask	layerMask = 3;

	[ContextMenu("load catacombs")]
	void LoadCatacombs(){
		SceneLoader.instance.StartCoroutine(SceneLoader.instance.EnterLevel(2));	
	}//to be removed on clean

	void OnTriggerEnter(Collider other)
	{
		if ((layerMask & (1 << other.gameObject.layer)) == 0) return;
		SceneLoader.instance.StartCoroutine(SceneLoader.instance.EnterLevel(2));	
	}
}
