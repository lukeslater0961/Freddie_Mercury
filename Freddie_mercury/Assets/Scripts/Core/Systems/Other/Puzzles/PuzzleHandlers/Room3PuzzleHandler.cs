using UnityEngine;

public class Room3PuzzleHandler : BasePuzzleHandler
{
    [SerializeField] private PlatePuzzle platePuzzle;

    private void Start()
    {
		WorldLimits.OnHit += HandlePuzzleFailed;
		Init();
	}

	private void onDisable()
	{
		WorldLimits.OnHit -= HandlePuzzleFailed;
	}

    protected override void RegisterPuzzles()
	{
        puzzles.Add(platePuzzle);
	}
}
