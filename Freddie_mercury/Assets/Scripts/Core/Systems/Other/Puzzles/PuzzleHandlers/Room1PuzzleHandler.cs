using UnityEngine;

public class Room1PuzzleHandler : BasePuzzleHandler
{
    [SerializeField] private TotemPuzzle totemPuzzle;

    private void Start()
    {
		Init();
	}

	private void OnDisable()
	{
		Debug.Log("puzzle 1 handler disabled");
		Cleanup();
	}

    protected override void RegisterPuzzles()
    {
		Debug.Log("Room1PuzzleHandler => registering puzzles");
        puzzles.Add(totemPuzzle);
    }
}
