using UnityEngine;
using System.Collections;

public class Asylum2State : LevelBaseState
{
	AsylumStateManager _manager;

    public override void EnterState(AsylumStateManager manager)
    {
        Debug.Log("Entered Asylum2");
		_manager =  manager;
    }

	public void QuitState()
	{
		Debug.Log("Leaving Asylum2");
		_manager.SwitchState(AsylumStateManager.asylum3State);
	}
}
