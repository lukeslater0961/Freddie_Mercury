using UnityEngine;
using System;

public class TotemPuzzle: MonoBehaviour, IPuzzle
{
    public event Action OnPuzzleFailed;
    public event Action OnCompleted;

    public bool IsCompleted { get; private set; }

	//function have objects linked to puzzle (totem positions) and answer array or something

	private void CheckAnswer()
	{
		//check answer array and array
		//
		//Invoke puzzle fail action to call reduce time in state
		OnPuzzleFailed?.Invoke();
		//
		//call complete if array's match
		Complete();
	}

	[ContextMenu("Completed Puzzle")]
    private void Complete()
    {
		Debug.Log("TotemPuzzle => Completed");
		Debug.Log("TotemPuzzle => listeners: " + (OnCompleted?.GetInvocationList()?.Length ?? 0));
        IsCompleted = true;
        OnCompleted?.Invoke();
    }
}
