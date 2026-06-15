using UnityEngine;
using System.Collections;

public class CatacombsEntranceState : LevelBaseState<CatacombsStateManager>
{
	CatacombsStateManager _manager;

    public override void EnterState(CatacombsStateManager manager)
    {
		Debug.Log("Entering Catacombs Entrance");
		_manager = manager;
		_manager.RaiseRoomCompleted();
		SubToEvents();
    }

	void SubToEvents()
	{
		Room1Entrance.OnEntranceExited += QuitState;
	}

	public override void UnsubToEvents()
	{
		Room1Entrance.OnEntranceExited -= QuitState;
	}

	public void QuitState()
	{
		Debug.Log("Leaving Catacombs Entrance");
		UnsubToEvents();
		_manager.SwitchState(CatacombsStateManager.catacombs1State);
	}
}
