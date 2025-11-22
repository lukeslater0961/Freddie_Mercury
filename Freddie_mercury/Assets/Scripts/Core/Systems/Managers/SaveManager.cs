using UnityEngine;

public class SaveManager : Singleton<SaveManager> 
{
	public int[] scores = new int[2];
	
	public void InitSave()
	{
		if (!PlayerPrefs.HasKey("AsylumScore"))
			InitScores();
		else
			LoadScores();
	}

	public void InitScores()
	{
		Debug.Log("SaveManager => Initializing scores");
		PlayerPrefs.SetInt("AsylumScore", 0);
		PlayerPrefs.SetInt("CatacombsScore", 0);
		LoadScores();
	}

	public void SaveTimeValue(int level, int timeVal)
	{
		Debug.Log("SaveManager => saving time value");
		switch(level)
		{
			case 0:
				if (timeVal < scores[0] || scores[0] == 0)
					PlayerPrefs.SetInt("CatacombsScore", timeVal);
				break;
			case 1:
				if (timeVal < scores[1] || scores[1] == 0)
					PlayerPrefs.SetInt("AsylumScore", timeVal);
				break;
		}
		PlayerPrefs.Save();
	}

	public void LoadScores()
	{
		Debug.Log("SaveManager => Loading scores");
		scores[0] = PlayerPrefs.GetInt("CatacombsScore");
		scores[1] = PlayerPrefs.GetInt("AsylumScore");
	}
	
	public void ClearSave()
	{
		Debug.Log("SaveManager => Clearing save ...");
		PlayerPrefs.DeleteAll();
		InitScores();
		UiManager.instance.SetStatsBoard(scores);
	}
}
