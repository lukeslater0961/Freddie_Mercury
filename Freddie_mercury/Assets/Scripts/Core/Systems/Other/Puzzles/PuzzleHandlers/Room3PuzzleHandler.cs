using UnityEngine;

public class Room3PuzzleHandler : BasePuzzleHandler
{
    [SerializeField] private PlatePuzzle platePuzzle;

    private void Start()
    {
		Lava.OnHit += HandlePuzzleFailed;
		Init();
	}

	private void onDisable()
	{
		Lava.OnHit -= HandlePuzzleFailed;
	}

    protected override void RegisterPuzzles()
	{
        puzzles.Add(platePuzzle);
	}
}
