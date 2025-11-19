using UnityEngine;
using System.Collections;

public class Catacombs2State : LevelBaseState<CatacombsStateManager>
{
	CatacombsStateManager _manager;

    public override void EnterState(CatacombsStateManager manager)
    {
        Debug.Log("Entered Catacombs2");
		_manager = manager;
    }


	public void QuitState()
	{
		Debug.Log("Leaving Catacombs3");
		_manager.SwitchState(CatacombsStateManager.catacombs3State);
	}
}
