using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
	public AsyncOperation LoadScene(int sceneIndex)
	{
		Debug.Log($"SceneLoader => Loading scene {sceneIndex}");
		return SceneManager.LoadSceneAsync(sceneIndex);
	}
}
