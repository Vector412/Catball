public class Player : Singleton<Player>
{
	private static int currentCoins;
	public delegate void OnCoinsChanged(int coins);
	public event OnCoinsChanged onCoinTake;
	public void AddCoin()
	{
		currentCoins++;
		onCoinTake.Invoke(currentCoins);
	}
}
