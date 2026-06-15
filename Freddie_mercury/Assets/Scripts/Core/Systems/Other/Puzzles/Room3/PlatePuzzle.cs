using UnityEngine;
using System;

public class PlatePuzzle : MonoBehaviour, IPuzzle 
{
	public event Action OnPuzzleFailed;
	public event Action OnCompleted;

	[SerializeField] private int[] answers = new int[3];
	private int index;

	public bool IsCompleted {get; private set;}

	void Start()
	{
		index = 0;
		PressurePlate.OnPressed += AddAnswer;
		Debug.Log("answers length = " + answers.Length);
	}

	void OnDestroy()
	{
		PressurePlate.OnPressed -= AddAnswer;
	}

	public void AddAnswer(int id)
	{
		answers[index++] = id;
		Debug.Log($"added {id} at index {index - 1}");
		
		Debug.Log($"checking index {index} compared to length {answers.Length}");
		if (index == answers.Length)
			CheckAnswer();
	}

	private void CheckAnswer()
	{
		for (int index = 0; index < answers.Length; index++)
		{
			if (answers[index] != index)
				FailPuzzle();
			else if (index == answers.Length - 1)
				Complete();
		}
	}

	private void FailPuzzle()
	{
		Debug.Log("Puzzle failed, resetting answers");
		
		Array.Clear(answers, 0, answers.Length);
		OnPuzzleFailed?.Invoke();
	}

    private void Complete()
    {
		Debug.Log("Puzzle completed");
		PressurePlate.OnPressed -= AddAnswer;
		IsCompleted = true;
		OnCompleted?.Invoke();
    }
}
