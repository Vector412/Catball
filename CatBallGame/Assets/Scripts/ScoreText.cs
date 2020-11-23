using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI scoreText;
	private void Start() => PlayerMovement.Instance.onCoinTake += OnPlayerCoinsChanged;
	void OnPlayerCoinsChanged(int newCoins) => scoreText.text = "Score: " + newCoins.ToString();
}
