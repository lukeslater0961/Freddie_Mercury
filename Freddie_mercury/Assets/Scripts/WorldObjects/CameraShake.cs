using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cam;
    private float shakeDuration = 0f;
    private float shakeAmount = 0.2f;
    private Vector3 originalPos;

    void Awake()
    {
        originalPos = cam.localPosition;
		BasePuzzleHandler.OnAllPuzzlesCompleted += DoCameraShake;
    }

	void OnDestroy()
	{
		BasePuzzleHandler.OnAllPuzzlesCompleted -= DoCameraShake;
	}

    void Update()
    {
        if (shakeDuration > 0)
        {
            cam.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            cam.localPosition = originalPos;
        }
    }

    public void DoCameraShake()
    {
        shakeDuration = 3f;
		Debug.Log("Doing camera shake");
    }
}
