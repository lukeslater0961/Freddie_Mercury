using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
	public void LoadAndWait(int sceneIndex)
	{
		StartCoroutine(LoadSceneCoRoutine(sceneIndex));
	}

    public AsyncOperation LoadScene(int sceneIndex)
    {
        Debug.Log($"SceneLoader => Loading scene {sceneIndex}");
        return SceneManager.LoadSceneAsync(sceneIndex);
    }

    public IEnumerator LoadSceneCoRoutine(int sceneIndex)
    {
        AsyncOperation asyncOp = LoadScene(sceneIndex);
		yield return asyncOp;
    }

	public IEnumerator EnterLevel(int sceneIndex)
	{
		yield return LoadSceneCoRoutine(sceneIndex);

		GameStateManager.instance.SwitchState(GameStateManager.levelState);
	}	
}
