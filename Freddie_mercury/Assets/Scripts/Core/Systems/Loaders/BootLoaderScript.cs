using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BootLoaderScript : MonoBehaviour
{
	[SerializeField]	List<GameObject>	coreSystems;

	private IEnumerator Start()
	{
		Debug.Log("BootLoader: Instantiating core systems");
		yield return BootSystems();
		GameStateManager.instance.SwitchState(GameStateManager.bootState);
	}

	private IEnumerator BootSystems()
	{
		foreach (GameObject sys in coreSystems)
			yield return Instantiate(sys);
	}
}
