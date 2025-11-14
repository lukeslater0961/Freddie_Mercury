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
        Debug.Log("Boot: Calling SceneLoader");

		//call all system init functions
		UiManager.instance.InitUi();

        AsyncOperation op = SceneLoader.instance.LoadScene(1);
        yield return op; 
    }
}
