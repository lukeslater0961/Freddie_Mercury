using UnityEngine;
using System;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;

public class PressurePlate : MonoBehaviour
{
	public static event Action<int> OnPressed;

	[SerializeField] private int id;

	private XRSimpleInteractable pokeInteractable;

	[ContextMenu("PressPlate")]
	public void PressPlate()
	{	
		OnPressed?.Invoke(id);
	}

	void Start()
	{
		Room3PuzzleHandler.OnAllPuzzlesCompleted += Hide;
	}

	void OnDestroy()
	{
		Room3PuzzleHandler.OnAllPuzzlesCompleted -= Hide;
	}

	void ResetBool()
	{
		isPressed = false;
	}

	void Hide()
	{
		gameObject.SetActive(false);
	}
}
