/*
TODO: Still need to abstract the Console.WriteLine() stuff
*/

using VendingMachineApp.Solid;
using VendingMachineApp.Solid.Interfaces;

namespace VendingMachineApp;

public class ExampleSolid
{
	public static void Run()
	{
		IVendingMachine vendingMachine = new VendingMachine(InitializeVendingMachineItems());
		IUser user = new User(10);
		IMenu menu = new Menu(vendingMachine, user);

		menu.Display();
	}

	private static List<IVendingMachineItem> InitializeVendingMachineItems()
	{
		return new List<IVendingMachineItem>
		{
			new VendingMachineItem("Coke", 1.5, 10),
			new VendingMachineItem("Pepsi", 1.5, 10),
			new VendingMachineItem("Water", 1.0, 10),
			new VendingMachineItem("Chips", 0.5, 10),
			new VendingMachineItem("Chocolate", 0.75, 10)
		};
	}
}
