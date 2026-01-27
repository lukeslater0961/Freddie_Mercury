using UnityEngine;
using System.Collections;

public class Catacombs3State : LevelBaseState<CatacombsStateManager>
{
	CatacombsStateManager _manager;

    public override void EnterState(CatacombsStateManager manager)
    {
        Debug.Log("Entered Catacombs3");
		_manager = manager;
		SubToEvents();
	}

	void SubToEvents()
	{
		Room3PuzzleHandler.OnPuzzleFailed += ApplyPenalty;
		Room3PuzzleHandler.OnAllPuzzlesCompleted += QuitState;
	}

	void UnSubToEvents()
	{
		Room3PuzzleHandler.OnPuzzleFailed -= ApplyPenalty;
		Room3PuzzleHandler.OnAllPuzzlesCompleted -= QuitState;
	}

	public void ApplyPenalty()
	{
		_manager.eventHandler.ApplyTimerPenalty(_manager);
	}

	public void QuitState()
	{
		Debug.Log("Leaving Catacombs3");
		UnSubToEvents();
		_manager.RaiseRoomCompleted();
		//_manager.SwitchState(CatacombsStateManager.catacombs4State);
	}

}
