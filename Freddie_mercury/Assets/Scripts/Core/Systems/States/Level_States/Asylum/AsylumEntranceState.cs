using UnityEngine;
using System.Collections;

public class AsylumEntranceState : LevelBaseState<AsylumStateManager>
{
	AsylumStateManager _manager;

    public override void EnterState(AsylumStateManager manager)
    {
        Debug.Log("Entered Asylum Entrance");
		_manager = manager;
		_manager.RaiseRoomCompleted();
		LevelEntrance.EntranceExited += QuitState;
    }

	public void QuitState()
	{
		Debug.Log("Leaving Asylum Entrance");
		LevelEntrance.EntranceExited -= QuitState;
		_manager.SwitchState(AsylumStateManager.asylum1State);
	}
}
