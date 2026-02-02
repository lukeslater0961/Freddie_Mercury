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
	}

	void OnDestroy()
	{
		PressurePlate.OnPressed -= AddAnswer;
	}

	public void AddAnswer(int id)
	{
		answers[index++] = id;
		Debug.Log($"added {id} at index {index}");
	}

	private void CheckAnswer()
	{
		
	}

	private void FailPuzzle()
	{
		Debug.Log("Puzzle failed, resetting answers");
		
		Array.Clear(answers, 0, answers.Length);
		OnPuzzleFailed?.Invoke();
	}

    private void Complete()
    {
		PressurePlate.OnPressed -= AddAnswer;
		OnCompleted?.Invoke();
    }
}
