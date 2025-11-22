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
		if (menu.WasPressedThisFrame())
			SceneLoader.instance.StartCoroutine(SceneLoader.instance.EnterMainMenu());
	}
}

