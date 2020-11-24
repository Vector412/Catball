using UnityEngine;


public class LevelLoader : MonoBehaviour
{
	[SerializeField] LevelList levels;
	private static int openedLevel;
	private void Start()
	{
		Time.timeScale = 1f;
		DontDestroyOnLoad(gameObject);
		Debug.Log(PlayerPrefs.GetInt("currentOpenedLevel"));
		Debug.Log(openedLevel);
		
		if (PlayerPrefs.GetInt("currentOpenedLevel") == 0)
		{
			PlayerPrefs.SetInt("currentOpenedLevel", 0);
			CreateLevel();
		}
		else
		{
			openedLevel = PlayerPrefs.GetInt("currentOpenedLevel");
			CreateLevel();
		}
	}
	public void LoadNextLevel()
	{
		CreateLevel();
	}
	public void DeleteSaves() => PlayerPrefs.DeleteAll();
	public void CreateLevel()
	{
		PlayerPrefs.SetInt("currentOpenedLevel", openedLevel++);
		Instantiate(levels.levelPrefabs[openedLevel]);
	}
}
