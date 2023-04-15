namespace VendingMachineApp.TaskFiles.Task5;

class User5
{
	public double Balance { get; private set; }

	public User5(double initialBalance)
	{
		Balance = initialBalance;
	}

	public bool HasEnoughBalance(double amount)
	{
		return Balance >= amount;
	}

	public void UpdateBalance(double amount)
	{
		Balance += amount;
	}
}