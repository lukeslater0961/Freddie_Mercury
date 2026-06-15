using UnityEngine;

public class Room2PuzzleHandler : BasePuzzleHandler
{
    private void Start()
    {
		Room2Exit.OnRoomExited += RaisePuzzlesCompleted;
		WrongExit.OnWrongExitTaken += HandlePuzzleFailed;
	}

	private void OnDisable()
	{
		Debug.Log("puzzle 2 handler disabled");
		Room2Exit.OnRoomExited -= RaisePuzzlesCompleted;
		WrongExit.OnWrongExitTaken -= HandlePuzzleFailed;
	}

    protected override void RegisterPuzzles(){}
}
