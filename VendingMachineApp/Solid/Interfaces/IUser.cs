namespace VendingMachineApp.Solid.Interfaces;

public interface IUser
{
	double Balance { get; }
	bool HasEnoughBalance(double amount);
	void UpdateBalance(double amount);
}