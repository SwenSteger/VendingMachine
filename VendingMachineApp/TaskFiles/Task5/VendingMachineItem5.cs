namespace VendingMachineApp.TaskFiles.Task5;

class VendingMachineItem5
{
	public string Name { get; set; }
	public double Price { get; set; }
	public int Stock { get; set; }

	public VendingMachineItem5(string name, double price, int stock)
	{
		Name = name;
		Price = price;
		Stock = stock;
	}
}