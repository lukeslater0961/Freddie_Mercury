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
		pokeInteractable = GetComponent<XRSimpleInteractable>();
		Debug.Log($"{pokeInteractable}");
		pokeInteractable.selectEntered.AddListener(HandlePress);
		isPressed = false;
		initialPosition = transform.position;
		Room3PuzzleHandler.OnPuzzleFailed += Reset;
		Room3PuzzleHandler.OnAllPuzzlesCompleted += Hide;
	}

	void OnDestroy()
	{
		Room3PuzzleHandler.OnPuzzleFailed -= Reset;
	}

	void Reset()
	{
		transform.position = Vector3.Lerp(transform.position, initialPosition, 1f);
		isPressed = false;
	}

	void Hide()
	{
		gameObject.SetActive(false);
	}
}
