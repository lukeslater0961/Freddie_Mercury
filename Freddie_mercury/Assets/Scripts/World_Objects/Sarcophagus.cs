using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Sarcophagus : Interactible
{
	[SerializeField]	Rigidbody	lid;
	private				XRSimpleInteractable interactor;

	void Start()
	{
		interactor = GetComponent<XRSimpleInteractable>();
	}

	public override void OnSelect()
	{
		lid.isKinematic = false;
		interactor.enabled = false;
	}
}
