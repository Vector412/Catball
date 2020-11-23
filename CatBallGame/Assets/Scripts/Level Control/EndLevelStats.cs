using UnityEngine;
using TMPro;

public class EndLevelStats : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI scoreText;
	[SerializeField] TextMeshProUGUI bonusText;

	private void OnEnable()
	{
		scoreText.text = "Final score: " + Player.Instance.currentCoins;
		bonusText.text = "Bonus: *Логика расчета из оставшегося запаса чернил*";
	}
}
