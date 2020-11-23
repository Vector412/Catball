using UnityEngine;

public class FinalFlag : MonoBehaviour
{
    [SerializeField] GameObject endLevelScreen;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
			FinishLevel();
	}
	private void FinishLevel() => endLevelScreen.SetActive(true);
}
