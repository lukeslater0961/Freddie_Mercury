using UnityEngine;
using System;

public class TotemPuzzle: MonoBehaviour, IPuzzle
{
    public event Action OnPuzzleFailed;
    public event Action OnCompleted;

	private bool?[] slotAnswers = new bool?[4];

    public bool IsCompleted { get; private set; }

	void Start()
	{
		Slot.OnObjectPlaced += AddAnswer;
	}

	void OnDestroy()
	{
		Slot.OnObjectPlaced -= AddAnswer;
	}

	public void AddAnswer(bool val, int index)
	{
		 int findFirstNull = Array.FindIndex(slotAnswers, x => x == null);
		 if (findFirstNull != -1)
			 slotAnswers[index] = val;

		 bool allFilled = Array.TrueForAll(slotAnswers, x => x.HasValue);
		 if (allFilled)
			 CheckAnswer();	
	}

	private void CheckAnswer()
	{
		Debug.Log("Checking answers");
		int firstTrueIndex = Array.FindIndex(slotAnswers, b => b == false);
		if (firstTrueIndex != -1)
			FailPuzzle();
		else
			Complete();
	}

	private void FailPuzzle()
	{
		Debug.Log("Puzzle failed, resetting answers");

		for (int i = 0; i < slotAnswers.Length; i++)
		{
			if (slotAnswers[i] == false)
				slotAnswers[i] = null;
		}

		OnPuzzleFailed?.Invoke();
	}

	[ContextMenu("Completed Puzzle")]//to be removed on clean
    private void Complete()
    {
		Debug.Log("TotemPuzzle => Completed");
		Debug.Log("TotemPuzzle => listeners: " + (OnCompleted?.GetInvocationList()?.Length ?? 0));

        IsCompleted = true;
		Slot.OnObjectPlaced -= AddAnswer;
        OnCompleted?.Invoke();
    }
}
