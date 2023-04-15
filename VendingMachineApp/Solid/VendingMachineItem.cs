using VendingMachineApp.Solid.Interfaces;

namespace VendingMachineApp.Solid;

internal class VendingMachineItem : IVendingMachineItem
{
	public string Name { get; }
	public double Price { get; }
	public int Stock { get; set; }

	public VendingMachineItem(string name, double price, int stock)
	{
		Name = name;
		Price = price;
		Stock = stock;
	}
}