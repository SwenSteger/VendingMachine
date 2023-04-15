using VendingMachineApp.Solid.Interfaces;

namespace VendingMachineApp.Solid;

internal class User : IUser
{
	public double Balance { get; private set; }

	public User(double initialBalance)
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