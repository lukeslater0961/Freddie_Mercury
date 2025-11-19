using UnityEngine;
using System.Collections;

public class Catacombs3State : LevelBaseState<CatacombsStateManager>
{
	CatacombsStateManager _manager;

    public override void EnterState(CatacombsStateManager manager)
    {
        Debug.Log("Entered Catacombs3");
		_manager = manager;
    }


	public void QuitState()
	{
	}
}
