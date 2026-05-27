using System.Collections;
using UnityEngine;
using System;
using TMPro;

public class StopWatch : MonoBehaviour
{
	public static Action OnTimerZero;
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
		CatacombsStateManager.ReduceTime -= SetTimer;
	}

    void Start()
    {
		SubscribeToEvents();
		currentTime = maxTime;
		UiManager.instance.SetAndInitWatch(this.gameObject);
		gameObject.SetActive(false);
    }

	void SubscribeToEvents()
	{
		CatacombsStateManager.ReduceTime += SetTimer;
	}

	public void StartTimer()
	{
		gameObject.SetActive(true);
		StartCoroutine(TimerSequence());
		Exit.OnLevelFinished += SaveTime;
	}

	public void SetText()
	{
		timeText.text = $"{GetMinutes(Mathf.FloorToInt(currentTime))}:{GetSeconds(Mathf.FloorToInt(currentTime)):00}";
		Debug.Log($"time set to {timeText.text}");
	}

	public int GetMinutes(int timeVal)
	{
		return Mathf.FloorToInt(timeVal / 60);
	}

	public int GetSeconds(int timeVal)
	{
		return	Mathf.FloorToInt(timeVal % 60);
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
		OnTimerZero?.Invoke();
	}

	void SaveTime()
	{
		int totalTime = (int)maxTime - Mathf.FloorToInt(currentTime);
		SaveManager.instance.SaveTimeValue(totalTime);
	}
}
