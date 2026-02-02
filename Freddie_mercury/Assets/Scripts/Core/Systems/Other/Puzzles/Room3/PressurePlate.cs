using UnityEngine;
using System;

public class PressurePlate : MonoBehaviour
{
	public static event Action<int> OnPressed;

	[SerializeField] private int id;

	private Transform	initialPosition;
	private bool		isPressed = false;
	
	void Start()
	{
		initialPosition = transform;
		Room3PuzzleHandler.OnPuzzleFailed += Reset;
	}

	void Destroy()
	{
		Room3PuzzleHandler.OnPuzzleFailed -= Reset;
	}

	void Update()
	{
		if (isPressed && (transform.position == initialPosition.position))
			return;
	
		isPressed = true;
		OnPressed?.Invoke(id);
	}

	void Reset()
	{
		transform.position = Vector3.Lerp(transform.position, initialPosition.position, 1f);
		isPressed = false;
	}
}
