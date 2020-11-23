
public class Player : Singleton<Player>
{
	public int currentCoins;
	public delegate void OnCoinsChanged(int coins);
	public event OnCoinsChanged onCoinTake;
	public void AddCoin()
	{
		currentCoins++;
		onCoinTake.Invoke(currentCoins);
	}
}
