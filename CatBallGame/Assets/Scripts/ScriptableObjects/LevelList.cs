using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "LevelList")]
public class LevelList : ScriptableObject
{
	public List<GameObject> levelPrefabs = new List<GameObject>();
}
