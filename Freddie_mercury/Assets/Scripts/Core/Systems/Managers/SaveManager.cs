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

	public void LoadScores()
	{
		Debug.Log("SaveManager => Loading scores");
		scores[0] = PlayerPrefs.GetInt("AsylumScore");
		scores[1] = PlayerPrefs.GetInt("CatacombsScore");
	}
	
	public void ClearSave()
	{
		Debug.Log("SaveManager => Clearing save ...");
		PlayerPrefs.DeleteAll();
	}
}
