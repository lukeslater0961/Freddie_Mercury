using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;

public class PressurePlate : MonoBehaviour
{
	public static event Action<int> OnPressed;

	[SerializeField] private int id;

	private Vector3	initialPosition;
	private bool		isPressed = false;
	private XRSimpleInteractable pokeInteractable;

	[ContextMenu("PressPlate")]
	public void PressPlate()
	{	
		if (isPressed) return;
		isPressed = true;
		OnPressed?.Invoke(id);
	}

	void Start()
	{
		isPressed = false;
		Room3PuzzleHandler.OnAllPuzzlesCompleted += Hide;
	}

	void OnDestroy()
	{
		Room3PuzzleHandler.OnAllPuzzlesCompleted -= Hide;
	}

	void Hide()
	{
		gameObject.SetActive(false);
	}
}
