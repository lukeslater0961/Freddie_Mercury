using UnityEngine;

public class Room2PuzzleHandler : BasePuzzleHandler
{
    private void Start()
    {
		Room2Exit.OnRoomExited += RaisePuzzlesCompleted;
		WrongExit.OnWrongExitTaken += HandlePuzzleFailed;
	}

	private void onDisable()
	{
		Room2Exit.OnRoomExited -= RaisePuzzlesCompleted;
		WrongExit.OnWrongExitTaken -= HandlePuzzleFailed;
	}

    protected override void RegisterPuzzles(){}
}
