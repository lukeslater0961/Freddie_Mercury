using UnityEngine;

public class SaveManager : Singleton<SaveManager> 
{
	public int[] scores = new int[2];
	
	public void InitSave()
	{
		if (!PlayerPrefs.HasKey("CatacombsScore"))
			InitScores();
		else
			LoadScores();
	}

	public void InitScores()
	{
		Debug.Log("SaveManager => Initializing scores");
		PlayerPrefs.SetInt("CatacombsScore", 0);
		LoadScores();
	}

	public void SaveTimeValue(int timeVal)
	{
		Debug.Log("SaveManager => saving time value");

		if (timeVal < scores[0] || scores[0] == 0)
			PlayerPrefs.SetInt("CatacombsScore", timeVal);

		PlayerPrefs.Save();
	}

	public void LoadScores()
	{
		Debug.Log("SaveManager => Loading scores");
		scores[0] = PlayerPrefs.GetInt("CatacombsScore");
	}
	
	public void ClearSave()
	{
		Debug.Log("SaveManager => Clearing save ...");
		PlayerPrefs.DeleteAll();
		InitScores();
		UiManager.instance.SetStatsBoard(scores);
	}
}
