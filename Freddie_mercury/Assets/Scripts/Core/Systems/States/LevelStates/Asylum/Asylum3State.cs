using UnityEngine;
using System.Collections;

public class Asylum3State : LevelBaseState<AsylumStateManager>
{
	AsylumStateManager _manager;

    public override void EnterState(AsylumStateManager manager)
    {
        Debug.Log("Entered Asylum3");
		_manager = manager;
    }
}
