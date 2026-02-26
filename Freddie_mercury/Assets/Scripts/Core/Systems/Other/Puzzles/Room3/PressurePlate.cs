using UnityEngine;
using System;

public class PressurePlate : MonoBehaviour
{
	public static event Action<int> OnPressed;

	[SerializeField] private int id;

	private Transform	initialPosition;
	private bool		isPressed = false;
	
	[ContextMenu("PressPlate")]
	public void PressPlate()
	{	
		isPressed = true;
		OnPressed?.Invoke(id);
	}

	void Start()
	{
		isPressed = false;
		initialPosition = transform;
		Room3PuzzleHandler.OnPuzzleFailed += Reset;
		Room3PuzzleHandler.OnAllPuzzlesCompleted += Hide;
	}

	void Destroy()
	{
		Room3PuzzleHandler.OnPuzzleFailed -= Reset;
	}

	void Update()
	{
		if (isPressed || (transform.position == initialPosition.position))
			return;
	
		isPressed = true;
		OnPressed?.Invoke(id);
	}

	void Reset()
	{
		transform.position = Vector3.Lerp(transform.position, initialPosition.position, 1f);
		isPressed = false;
	}

	void Hide()
	{
		gameObject.SetActive(false);
	}
}
