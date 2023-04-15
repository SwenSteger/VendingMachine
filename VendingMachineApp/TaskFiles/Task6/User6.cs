namespace VendingMachineApp.TaskFiles.Task6;

class User6
{
	public double Balance { get; private set; }

	public User6(double initialBalance)
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