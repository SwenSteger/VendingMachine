namespace VendingMachineApp.Solid.Interfaces;

public interface IVendingMachineItem
{
	string Name { get; }
	double Price { get; }
	int Stock { get; set; }
}