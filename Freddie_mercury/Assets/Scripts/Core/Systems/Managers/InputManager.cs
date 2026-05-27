using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
	private InputAction menu;

	void Start()
	{
		menu = InputSystem.actions.FindAction("menu");
	}

	void Update()
	{
		if (menu.WasPressedThisFrame())//change to event
			SceneLoader.instance.StartCoroutine(SceneLoader.instance.EnterMainMenu());
	}

	[ContextMenu("load mainmenu")]
	void EnterMainMenu()
	{
		SceneLoader.instance.StartCoroutine(SceneLoader.instance.EnterMainMenu());
	}
}

