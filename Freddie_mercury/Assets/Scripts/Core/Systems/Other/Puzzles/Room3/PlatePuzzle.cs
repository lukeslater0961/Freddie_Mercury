using UnityEngine;
using System;
using System.Collections.Generic;

public class PlatePuzzle : MonoBehaviour, IPuzzle 
{
	public static event Action ResetPlate;
	public event Action OnPuzzleFailed;
	public event Action OnCompleted;

	[SerializeField] private List<int> answers = new List<int>(3);

	public bool IsCompleted {get; private set;}

	void Start()
	{
		PressurePlate.OnPressed += AddAnswer;
		answers.Clear();
	}

	void OnDestroy()
	{
		PressurePlate.OnPressed -= AddAnswer;
		answers = null;
	}

	public void AddAnswer(int id)
	{
	    if (answers.Contains(id))
			return;

		answers.Add(id);

		if (answers.Count == 3)
			CheckAnswer();	
	}

	private void CheckAnswer()
	{
		for (int i = 0; i < answers.Count; i++)
		{
			if (answers[i] != i)
			{
				FailPuzzle();
				return;         
			}
		}

		Complete();
	}

	private void FailPuzzle()
	{
		Debug.Log("Puzzle failed, resetting answers");
		
		answers.Clear();
		OnPuzzleFailed?.Invoke();
		ResetPlate?.Invoke();
	}

    private void Complete()
    {
		Debug.Log("Puzzle completed");
		PressurePlate.OnPressed -= AddAnswer;
		IsCompleted = true;
		OnCompleted?.Invoke();
    }
}
