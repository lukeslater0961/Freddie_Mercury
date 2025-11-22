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
		LevelEntrance.EntranceExited += QuitState;
    }

	public void QuitState()
	{
		Debug.Log("Leaving Catacombs Entrance");
		LevelEntrance.EntranceExited -= QuitState;
		_manager.SwitchState(CatacombsStateManager.catacombs1State);
	}
}
