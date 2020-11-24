using UnityEngine;

public class LevelLoader : MonoBehaviour
{
	[SerializeField] LevelList levels;
	private static int openedLevel;
	private GameObject level;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	private void Start()
	{
		if (PlayerPrefs.GetInt("currentOpenedLevel") == 0)
		{
			PlayerPrefs.SetInt("currentOpenedLevel", 0);
			level = levels.levelPrefabs[PlayerPrefs.GetInt("currentOpenedLevel")];
			CreateLevel(level);
		}
		else
		{
			openedLevel = PlayerPrefs.GetInt("currentOpenedLevel");
			level = levels.levelPrefabs[PlayerPrefs.GetInt("currentOpenedLevel")];
			CreateLevel(level);
		}
	}
	public void LoadNextLevel()
	{
		Destroy(level);
		SaveProgress();
		level = levels.levelPrefabs[PlayerPrefs.GetInt("currentOpenedLevel")];
		CreateLevel(level);
	}
	public void SaveProgress() => PlayerPrefs.SetInt("currentOpenedLevel", openedLevel++);
	public void DeleteSaves() => PlayerPrefs.DeleteAll();
	public void CreateLevel(GameObject levelToCreate)
	{
		Instantiate(levelToCreate);
	}
}
