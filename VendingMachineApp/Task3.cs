/*
Task 3: Creating classes for User, VendingMachineItem, and VendingMachineApp:

- Create a VendingMachineItem class with properties for name and price.
- Create a VendingMachineApp class that holds a list of VendingMachineItem objects and a quantity of stock for a given item.
- Update the main method to use these new classes.
 */

using VendingMachineApp.TaskFiles.Task3;

namespace VendingMachineApp;

class Task3
{
	public static void Run()
	{
		VendingMachine3 vendingMachine = InitializeVendingMachine();
		bool continueLoop = true;

		while (continueLoop)
		{
			DisplayMenu(vendingMachine);
			string userInput = GetUserInput();

			if (userInput.ToLower() == "exit")
			{
				continueLoop = false;
			}
			else
			{
				int itemIndex = ValidateInput(userInput, vendingMachine.Items.Count);
				if (itemIndex >= 0)
				{
					VendingMachineItem3 selectedItem = GetSelectedItem(vendingMachine, itemIndex);
					DisplaySelectedItem(selectedItem);
				}
				else
				{
					Console.WriteLine("Invalid selection. Please try again.");
				}
			}
		}
	}

	static VendingMachine3 InitializeVendingMachine()
	{
		List<VendingMachineItem3> items = new List<VendingMachineItem3>
		{
			new VendingMachineItem3("Coke", 1.5),
			new VendingMachineItem3("Pepsi", 1.5),
			new VendingMachineItem3("Water", 1.0),
			new VendingMachineItem3("Chips", 0.5),
			new VendingMachineItem3("Chocolate", 0.75)
		};
		return new VendingMachine3(items);
	}

	static void DisplayMenu(VendingMachine3 vendingMachine)
	{
		Console.WriteLine("\nVending Machine Menu:");
		for (int i = 0; i < vendingMachine.Items.Count; i++)
		{
			Console.WriteLine($"{i + 1} - {vendingMachine.Items[i].Name} - ${vendingMachine.Items[i].Price}");
		}
	}

	static string GetUserInput()
	{
		Console.WriteLine("Enter the item number to purchase or type 'exit' to quit:");
		return Console.ReadLine();
	}

	static int ValidateInput(string userInput, int maxIndex)
	{
		if (int.TryParse(userInput, out int selection))
		{
			if (selection >= 1 && selection <= maxIndex)
			{
				return selection - 1;
			}
		}

		return -1;
	}

	static VendingMachineItem3 GetSelectedItem(VendingMachine3 vendingMachine, int userInput)
	{
		return vendingMachine.Items[userInput - 1];
	}

	static void DisplaySelectedItem(VendingMachineItem3 selectedItem)
	{
		Console.WriteLine($"You have selected: {selectedItem.Name}, Price: ${selectedItem.Price}");
	}
}