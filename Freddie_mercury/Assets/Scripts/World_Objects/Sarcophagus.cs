using UnityEngine;

public class Sarcophagus : Interactible
{
	[SerializeField]	Rigidbody	lid;


	[ContextMenu ("interact with Sarcophagus")]
	public override void OnSelect()
	{
		Debug.Log("sarcophargus interacted with");
		lid.isKinematic = false;
		Debug.Log($"rb is kinematic {lid.isKinematic}");
	}
}
