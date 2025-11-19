using UnityEngine;
using System.Collections;

public class Asylum1State : LevelBaseState<AsylumStateManager>
{
	AsylumStateManager _manager;

    public override void EnterState(AsylumStateManager manager)
    {
        Debug.Log("Entered Asylum1");
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
		Debug.Log("Leaving Asylum1");
		_manager.SwitchState(AsylumStateManager.asylum2State);
	}
}
