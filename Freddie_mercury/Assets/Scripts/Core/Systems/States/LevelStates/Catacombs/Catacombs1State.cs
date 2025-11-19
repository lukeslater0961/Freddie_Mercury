using UnityEngine;
using System.Collections;

public class Catacombs1State : LevelBaseState<CatacombsStateManager>
{
	CatacombsStateManager _manager;

    public override void EnterState(CatacombsStateManager manager)
    {
		Debug.Log("Entering Catacombs1");
		_manager = manager;
		_manager.RunCoroutine(StartTimer());
    }

	public IEnumerator StartTimer()
	{
		yield return new WaitForSeconds(3);
		UiManager.instance.StartTimerdw();	
	}

	public void QuitState()
	{
		Debug.Log("Leaving Catacombs1");
		_manager.SwitchState(CatacombsStateManager.catacombs2State);
	}
}
