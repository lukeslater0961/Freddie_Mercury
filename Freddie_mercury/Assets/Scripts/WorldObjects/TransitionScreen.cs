using UnityEngine;

public class TransitionScreen : MonoBehaviour
{
    [SerializeField]   Animator controller;

    void Awake()
    {
        SceneLoader.OnLoadScene += FadeOut;
    }

	void OnDestroy()
	{
        SceneLoader.OnLoadScene -= FadeOut;
	}

    void FadeOut()
    {
        controller.SetTrigger("FadeOut");
    }
}
