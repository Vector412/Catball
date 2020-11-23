using UnityEngine;
using TMPro;

public class EndLevelStats : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI coinsText;
	[SerializeField] TextMeshProUGUI bonusText;
	[SerializeField] TextMeshProUGUI finalScoreText;

	private void OnEnable()
	{
		coinsText.text = "Coins: " + Player.Instance.currentCoins;
		bonusText.text = "Bonus: Логика расчета из оставшегося запаса чернил " + 2;
		finalScoreText.text = "Final score: " + ((Player.Instance.currentCoins * 2) * 1.75);
	}
}
