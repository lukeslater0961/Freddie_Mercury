using UnityEngine;

public class Room1PuzzleHandler : BasePuzzleHandler
{
	//add puzzles
    [SerializeField] private TotemPuzzle totemPuzzle;

    protected override void RegisterPuzzles()
    {
		//move puzzles to array
        puzzles.Add(totemPuzzle);
    }
}
