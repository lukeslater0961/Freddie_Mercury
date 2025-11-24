using System;
using UnityEngine;
using System.Collections;

public interface IPuzzle
{
    event Action OnCompleted;
    event Action OnPuzzleFailed;

    bool IsCompleted { get; }
}

