/*
Task 4: Adding methods for transactions and stock management:

- Create a User class with a property for tracking the user's balance.
- Add methods to the User class for modifying the balance upon a transaction and verifying if the user has enough balance to purchase an item.
- Add methods to the VendingMachineApp class for removing from the quantity upon a successful purchase and updating the list to display remaining stock.
- Update the main method to call these methods when a user makes a purchase.
 */

using VendingMachineApp.TaskFiles.Task4;

namespace VendingMachineApp;

class Task4
{
	public static void Run()
	{
		VendingMachine4 vendingMachine = InitializeVendingMachine();
		User4 user = new User4(10);
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
					VendingMachineItem4 selectedItem = GetSelectedItem(vendingMachine, itemIndex);
					if (user.HasEnoughBalance(selectedItem.Price))
					{
						if (vendingMachine.IsItemInStock(selectedItem))
						{
							user.UpdateBalance(-selectedItem.Price);
							vendingMachine.UpdateStock(selectedItem, -1);
							DisplaySelectedItem(selectedItem);
							Console.WriteLine($"Your remaining balance: ${user.Balance}");
						}
						else
						{
							Console.WriteLine("Sorry, the item is out of stock.");
						}
					}
					else
					{
						Console.WriteLine("Insufficient balance. Please try another item.");
					}
				}
				else
				{
					Console.WriteLine("Invalid selection. Please try again.");
				}
			}
		}
	}
	
	static void DisplayMenu(VendingMachine4 vendingMachine)
	{
		Console.WriteLine("\nVending Machine Menu:");
		for (int i = 0; i < vendingMachine.Items.Count; i++)
		{
			Console.WriteLine($"{i + 1} - {vendingMachine.Items[i].Name} - ${vendingMachine.Items[i].Price}");
		}
	}
	
	static string GetUserInput()
	{
		Console.WriteLine("Enter the item name to purchase or type 'exit' to quit:");
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

	static void DisplaySelectedItem(VendingMachineItem4 selectedItem)
	{
		Console.WriteLine($"You have selected: {selectedItem.Name}, Price: ${selectedItem.Price}");
	}
	
	static VendingMachineItem4 GetSelectedItem(VendingMachine4 vendingMachine, int userInput)
	{
		return vendingMachine.Items[userInput];
	}
    
	static VendingMachine4 InitializeVendingMachine()
	{
		List<VendingMachineItem4> items = new List<VendingMachineItem4>
		{
			new VendingMachineItem4("Coke", 1.5, 10),
			new VendingMachineItem4("Pepsi", 1.5, 10),
			new VendingMachineItem4("Water", 1.0, 10),
			new VendingMachineItem4("Chips", 0.5, 10),
			new VendingMachineItem4("Chocolate", 0.75, 10)
		};
		return new VendingMachine4(items);
	}
}