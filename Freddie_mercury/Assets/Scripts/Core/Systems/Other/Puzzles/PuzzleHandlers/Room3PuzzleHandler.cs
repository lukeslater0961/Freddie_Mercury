using UnityEngine;

public class Room3PuzzleHandler : BasePuzzleHandler
{
    private void Start()
    {
		Lava.OnHit += HandlePuzzleFailed;
	}

	private void onDisable()
	{
		Lava.OnHit -= HandlePuzzleFailed;
	}

    protected override void RegisterPuzzles(){}
}
