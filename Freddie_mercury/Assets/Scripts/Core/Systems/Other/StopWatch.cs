using System.Collections;
using UnityEngine;
using System;
using TMPro;

public class StopWatch : MonoBehaviour
{
	public static event Action saveTime;

	[SerializeField]	TextMeshProUGUI	timeText;

	private float	currentTime;
	private float	maxTime = 600f;

	void Awake()
	{
		UiManager.InitTimer += SetText;
		UiManager.StartTimer += StartTimer;
	}

	void OnDestroy()
	{
		UiManager.InitTimer -= SetText;
		UiManager.StartTimer -= StartTimer;
	}

    void Start()
    {
		if (SceneLoader.instance.currentScene == 1)
			gameObject.SetActive(false);
		currentTime = maxTime;
		UiManager.instance.SetAndInitWatch(this.gameObject);
    }

	public void StartTimer()
	{
		StartCoroutine(TimerSequence());
	}

	public void SetText()
	{
		timeText.text = $"{GetMinutes()}:{GetSeconds()}";
		Debug.Log($"time set to {timeText.text}");
	}

	int GetMinutes()
	{
		return Mathf.FloorToInt(currentTime / 60f);
	}

	int GetSeconds()
	{
		return	Mathf.FloorToInt(currentTime % 60f);
	}

	private IEnumerator TimerSequence()
	{
		while(currentTime > 0)
		{
			currentTime -= Time.deltaTime;
			timeText.text = $"{Mathf.FloorToInt(currentTime / 60)}:{Mathf.FloorToInt(currentTime % 60)}";
			yield return null;
		}
	}
}
