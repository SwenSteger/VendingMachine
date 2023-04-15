namespace VendingMachineApp.TaskFiles.Task6;

class VendingMachineItem6
{
	public string Name { get; set; }
	public double Price { get; set; }
	public int Stock { get; set; }

	public VendingMachineItem6(string name, double price, int stock)
	{
		Name = name;
		Price = price;
		Stock = stock;
	}
}