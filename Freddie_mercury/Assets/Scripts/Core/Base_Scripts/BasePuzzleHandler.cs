using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class BasePuzzleHandler : MonoBehaviour
{
    public static event Action OnAllPuzzlesCompleted;
    public static event Action OnPuzzleFailed;

    [SerializeField ]protected List<IPuzzle> puzzles = new();

    public virtual void Init()
    {
        RegisterPuzzles();
        SubscribeToPuzzleEvents();
    }

    protected abstract void RegisterPuzzles();

    protected virtual void SubscribeToPuzzleEvents()
    {
        foreach (var p in puzzles)
		{
			Debug.Log($"subscribing to events of {p}");
			p.OnPuzzleFailed += HandlePuzzleFailed;
			p.OnCompleted += HandlePuzzleCompleted;
		}
    }

    protected virtual void HandlePuzzleCompleted()
    {
		Debug.Log("Puzzle Handler => checking completed");
        if (AllPuzzlesSolved())
			OnAllPuzzlesCompleted?.Invoke();
    }

	protected virtual void RaisePuzzlesCompleted()
	{
		OnAllPuzzlesCompleted?.Invoke();
		Debug.Log("puzzles completed called => listeners: " + (OnAllPuzzlesCompleted?.GetInvocationList()?.Length ?? 0));
	}

	protected virtual void HandlePuzzleFailed()
	{
		OnPuzzleFailed?.Invoke();
	}

    protected bool AllPuzzlesSolved()
    {
        return puzzles.TrueForAll(p => p.IsCompleted);
    }

    public virtual void Cleanup()
    {
        foreach (var p in puzzles)
		{
			p.OnPuzzleFailed -= HandlePuzzleFailed;
			p.OnCompleted -= HandlePuzzleCompleted;
		}
    }
}

