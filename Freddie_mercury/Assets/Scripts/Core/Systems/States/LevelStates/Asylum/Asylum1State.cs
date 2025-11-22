using UnityEngine;
using System.Collections;

public class Asylum1State : LevelBaseState<AsylumStateManager>
{
	AsylumStateManager _manager;

    public override void EnterState(AsylumStateManager manager)
    {
        Debug.Log("Entered Asylum1");
		_manager = manager;
		UiManager.instance.StartTimerdw();
    }

	public void QuitState()
	{
		Debug.Log("Leaving Asylum1");
		_manager.RaiseRoomCompleted();
		_manager.SwitchState(AsylumStateManager.asylum2State);
	}
}
