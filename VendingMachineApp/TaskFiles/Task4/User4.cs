namespace VendingMachineApp.TaskFiles.Task4;

class User4
{
	public double Balance { get; private set; }

	public User4(double initialBalance)
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