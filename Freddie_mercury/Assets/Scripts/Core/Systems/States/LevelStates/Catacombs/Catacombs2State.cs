using UnityEngine;
using System.Collections;

public class Catacombs2State : LevelBaseState<CatacombsStateManager>
{
	CatacombsStateManager _manager;

    public override void EnterState(CatacombsStateManager manager)
    {
        Debug.Log("Entered Catacombs2");
		_manager = manager;
		SubToEvents();
    }

	void SubToEvents()
	{
		Room2PuzzleHandler.OnPuzzleFailed += ApplyPenalty;
		Room2PuzzleHandler.OnAllPuzzlesCompleted += QuitState;
	}

	void UnSubToEvents()
	{
		Room2PuzzleHandler.OnPuzzleFailed -= ApplyPenalty;
		Room2PuzzleHandler.OnAllPuzzlesCompleted -= QuitState;
	}

	public void ApplyPenalty()
	{
		_manager.eventHandler.ApplyTimerPenalty(_manager);
	}

	public void QuitState()
	{
		Debug.Log("Leaving Catacombs2");
		UnSubToEvents();
		_manager.RaiseRoomCompleted();
		_manager.SwitchState(CatacombsStateManager.catacombs3State);
	}
}
