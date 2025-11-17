using UnityEngine;
using System.Collections;

public class BootState : GameBaseState
{
    public override IEnumerator EnterState(GameStateManager manager)
    {
        Debug.Log("Entered boot state");

        yield return InitializeSystems(manager);
        GameStateManager.instance.SwitchState(GameStateManager.mainMenuState);
    }

    private IEnumerator InitializeSystems(GameStateManager manager)
    {
		Debug.Log("Boot: Initializing core systems");

		//call all system init functions
		UiManager.instance.InitUi();
		AudioManager.instance.InitAudio();
		SaveManager.instance.InitSave();

        AsyncOperation op = SceneLoader.instance.LoadScene(1);
        yield return op; 
    }

	public override IEnumerator QuitState(GameStateManager manager)
	{
		Debug.Log("Quitting Boot State");
		yield break;
	}
}
