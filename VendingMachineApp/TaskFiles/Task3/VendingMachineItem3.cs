namespace VendingMachineApp.TaskFiles.Task3;

class VendingMachineItem3
{
	public string Name { get; set; }
	public double Price { get; set; }

	public VendingMachineItem3(string name, double price)
	{
		Name = name;
		Price = price;
	}
}