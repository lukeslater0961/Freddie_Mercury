using UnityEngine;
using System.Collections;

public class Catacombs1State : LevelBaseState<CatacombsStateManager>
{
	CatacombsStateManager _manager;

    public override void EnterState(CatacombsStateManager manager)
    {
		Debug.Log("Entering Catacombs1");
		_manager = manager;
		UiManager.instance.StartTimerdw();
		SubToEvents();
    }

	void SubToEvents()
	{
		Room1PuzzleHandler.OnPuzzleFailed += ApplyPenalty;
		Room1PuzzleHandler.OnAllPuzzlesCompleted += QuitState;
	}

	void UnSubToEvents()
	{
		Room1PuzzleHandler.OnPuzzleFailed -= ApplyPenalty;
		Room1PuzzleHandler.OnAllPuzzlesCompleted -= QuitState;
	}

	public void ApplyPenalty()
	{
		_manager.eventHandler.ApplyTimerPenalty(_manager);
	}

	public void QuitState()
	{
		Debug.Log("Leaving Catacombs1");

		UnSubToEvents();
		_manager.RaiseRoomCompleted();
		_manager.SwitchState(CatacombsStateManager.catacombs2State);
	}
}
