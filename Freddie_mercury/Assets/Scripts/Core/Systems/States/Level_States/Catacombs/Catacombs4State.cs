using UnityEngine;
using System.Collections;

public class Catacombs4State : LevelBaseState<CatacombsStateManager>
{
	CatacombsStateManager _manager;

    public override void EnterState(CatacombsStateManager manager)
    {
        Debug.Log("Entered Catacombs4");
		_manager = manager;
	}

	public override void UnsubToEvents(){}

	public void ApplyPenalty()
	{
		_manager.eventHandler.ApplyTimerPenalty(_manager);
	}

	public void QuitState()
	{
		Debug.Log("Leaving Catacombs4");
		_manager.RaiseRoomCompleted();
	}
}
