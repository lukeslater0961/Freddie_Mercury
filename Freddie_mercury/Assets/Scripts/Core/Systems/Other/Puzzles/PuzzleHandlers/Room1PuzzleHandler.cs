using UnityEngine;

public class Room1PuzzleHandler : BasePuzzleHandler
{
    [SerializeField] private TotemPuzzle totemPuzzle;

    private void Start()
    {
		Init();
	}

	private void onDisable()
	{
		Cleanup();
	}

    protected override void RegisterPuzzles()
    {
		Debug.Log("Room1PuzzleHandler => registering puzzles");
        puzzles.Add(totemPuzzle);
    }
}
