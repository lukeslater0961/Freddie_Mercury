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
		//subscribe to puzzle hander events
		//one event will be all puzzles cleared kinda thing += QuitState
	}

	public void QuitState()
	{
		Debug.Log("Leaving Catacombs2");
		_manager.RaiseRoomCompleted();
		_manager.SwitchState(CatacombsStateManager.catacombs3State);
	}
}
