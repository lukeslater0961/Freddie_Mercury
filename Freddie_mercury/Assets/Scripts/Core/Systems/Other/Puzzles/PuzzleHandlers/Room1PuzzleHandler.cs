using UnityEngine;

public class Room1PuzzleHandler : BasePuzzleHandler
{
	//add puzzles
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
		//move puzzles to array
        puzzles.Add(totemPuzzle);
    }
}
