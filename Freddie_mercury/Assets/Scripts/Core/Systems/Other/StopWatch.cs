using System.Collections;
using UnityEngine;
using System;
using TMPro;

public class StopWatch : MonoBehaviour
{
	[SerializeField]	TextMeshProUGUI	timeText;

	public float	currentTime;
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
		SubscribeToEvents();
		currentTime = maxTime;
		UiManager.instance.SetAndInitWatch(this.gameObject);
    }

	void SubscribeToEvents()
	{
		if (FindAnyObjectByType<Exit>() != null)
			Exit.OnLevelFinished += SaveTime;
		if (LevelInitializerService.current is AsylumInitializer)
			AsylumStateManager.ReduceTime += SetTimer;
		else if (LevelInitializerService.current is CatacombsInitializer)
			CatacombsStateManager.ReduceTime += SetTimer;
	}

	public void StartTimer()
	{
		StartCoroutine(TimerSequence());
	}

	public void SetText()
	{
		timeText.text = $"{GetMinutes(Mathf.FloorToInt(currentTime))}:{GetSeconds(Mathf.FloorToInt(currentTime))}";
		Debug.Log($"time set to {timeText.text}");
	}

	public int GetMinutes(int timeVal)
	{
		return Mathf.FloorToInt(timeVal / 60f);
	}

	public int GetSeconds(int timeVal)
	{
		return	Mathf.FloorToInt(timeVal % 60f);
	}

	void SetTimer(int penalty)
	{
		currentTime -= penalty;
	}

	private IEnumerator TimerSequence()
	{
		while (currentTime > 0)
		{
			int minutes = (int)(currentTime / 60);
			int seconds = (int)(currentTime % 60);

			timeText.text = $"{minutes}:{seconds:00}";
			yield return new WaitForSeconds(1f);
			currentTime--;
		}
		timeText.text = "0:00";
	}

	void SaveTime()
	{
		int totalTime = (int)maxTime - Mathf.FloorToInt(currentTime);
		if (LevelInitializerService.current is CatacombsInitializer)
			SaveManager.instance.SaveTimeValue(0, totalTime);
		else if (LevelInitializerService.current is AsylumInitializer)
			SaveManager.instance.SaveTimeValue(1, totalTime);
	}
}
