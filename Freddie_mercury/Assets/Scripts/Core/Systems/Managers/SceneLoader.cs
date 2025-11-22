using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
	public static event Action OnLoadScene;
	public int currentScene;

	public IEnumerator EnterLevel(int sceneIndex)
	{
		OnLoadScene?.Invoke();
		yield return new WaitForSeconds(0.9f);
		yield return LoadSceneCoRoutine(sceneIndex);

		GameStateManager.instance.SwitchState(GameStateManager.levelState);
	}

	public IEnumerator EnterMainMenu()
	{
		if (currentScene != 1)
		{
			yield return LoadSceneCoRoutine(1);
			GameStateManager.instance.SwitchState(GameStateManager.mainMenuState);
		}
		yield break;
	}

	private AsyncOperation LoadScene(int sceneIndex)
	{
		Debug.Log($"SceneLoader => Loading scene {sceneIndex}");
		currentScene = sceneIndex;
		return SceneManager.LoadSceneAsync(sceneIndex);
	}

	public IEnumerator LoadSceneCoRoutine(int sceneIndex)
	{
		AsyncOperation asyncOp = LoadScene(sceneIndex);
		yield return asyncOp;
	}
}
