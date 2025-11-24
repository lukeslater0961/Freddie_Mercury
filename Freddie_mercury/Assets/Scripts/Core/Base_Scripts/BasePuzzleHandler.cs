using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class BasePuzzleHandler : MonoBehaviour
{
    public static event Action OnAllPuzzlesCompleted;
    public static event Action OnPuzzleFailed;

    protected List<IPuzzle> puzzles = new();

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
			p.OnPuzzleFailed += HandlePuzzleFailed;
			p.OnCompleted += HandlePuzzleCompleted;
		}
    }

    protected virtual void HandlePuzzleCompleted()
    {
        if (AllPuzzlesSolved())
            OnAllPuzzlesCompleted?.Invoke();
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
            p.OnCompleted -= HandlePuzzleCompleted;
    }
}

