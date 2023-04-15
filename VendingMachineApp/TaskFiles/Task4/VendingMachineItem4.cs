namespace VendingMachineApp.TaskFiles.Task4;

class VendingMachineItem4
{
	public string Name { get; set; }
	public double Price { get; set; }
	public int Stock { get; set; }

	public VendingMachineItem4(string name, double price, int stock)
	{
		Name = name;
		Price = price;
		Stock = stock;
	}
}