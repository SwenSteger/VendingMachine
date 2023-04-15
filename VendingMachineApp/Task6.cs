/*
Task 7: Enhance the purchase process with quantity and confirmation

- Update the purchase process to prompt the user for the quantity of items to purchase after selecting an item by index.
- Use Console.ReadKey to accept quantity input from 1-9, with 1 as the default if the user presses ENTER, and cancel the transaction if the user presses ESC.
- Add a confirmation dialog after the user picks a quantity, displaying a summary of the chosen item, quantity, and total cost.
- Allow the user to confirm or cancel the purchase using Y/N or ENTER/ESC.
- Update the VendingMachineApp class and methods accordingly to handle the new purchase process and quantity management.
*/

using VendingMachineApp.TaskFiles.Task6;

namespace VendingMachineApp;

class Task6
{
	public static void Run()
	{
		VendingMachine6 vendingMachine = InitializeVendingMachine();
		User6 user = new User6(10);
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
				if (int.TryParse(userInput, out var itemIndex))
				{
					int quantity = GetQuantity();
					if (quantity > 0)
					{
						HandleUserTransaction(vendingMachine, user, itemIndex - 1, quantity);
					}
					else
					{
						Console.WriteLine("Transaction cancelled.");
					}
				}
			}
		}
	}
	
	static VendingMachine6 InitializeVendingMachine()
	{
		List<VendingMachineItem6> items = new List<VendingMachineItem6>
		{
			new VendingMachineItem6("Coke", 1.5, 10),
			new VendingMachineItem6("Pepsi", 1.5, 10),
			new VendingMachineItem6("Water", 1.0, 10),
			new VendingMachineItem6("Chips", 0.5, 10),
			new VendingMachineItem6("Chocolate", 0.75, 10)
		};
		return new VendingMachine6(items);
	}

	static void DisplayMenu(VendingMachine6 vendingMachine)
	{
		Console.WriteLine("\nVending Machine Menu:");
		for (int i = 0; i < vendingMachine.Items.Count; i++)
		{
			VendingMachineItem6 item = vendingMachine.Items[i];
			Console.WriteLine($"{i + 1}. {item.Name} - ${item.Price}");
		}
	}

	static string GetUserInput()
	{
		Console.WriteLine("Enter the item number to purchase or type 'exit' to quit:");
		return Console.ReadLine();
	}

	static void DisplaySelectedItem(VendingMachineItem6 selectedItem, int quantity, double totalPrice)
	{
		Console.WriteLine($"You have selected {quantity} units of {selectedItem.Name}, Price: ${totalPrice}");
	}
	
	static int GetQuantity()
	{
		Console.WriteLine("Enter the quantity to purchase (1-9):");
		Console.WriteLine("Press ENTER for default quantity (1) or ESC to cancel.");

		while (true)
		{
			ConsoleKeyInfo keyInfo = Console.ReadKey(true);
			if (keyInfo.Key == ConsoleKey.Escape)
			{
				return 0; // Cancel
			}
			else if (keyInfo.Key == ConsoleKey.Enter)
			{
				return 1; // Default quantity
			}
			else if (char.IsDigit(keyInfo.KeyChar))
			{
				int quantity = int.Parse(keyInfo.KeyChar.ToString());
				if (quantity >= 1 && quantity <= 9)
				{
					return quantity;
				}
			}
			else
			{
				Console.WriteLine("Invalid input. Please try again.");
			}
		}
	}

	static bool ConfirmPurchase(VendingMachineItem6 selectedItem, User6 user, int quantity)
	{
		double totalCost = selectedItem.Price * quantity;
		Console.WriteLine($"\nPurchase summary:");
		Console.WriteLine($"Item: {selectedItem.Name}");
		Console.WriteLine($"Quantity: {quantity}");
		Console.WriteLine($"Total cost: ${totalCost}");
		Console.WriteLine($"Current balance: ${user.Balance}");
		Console.WriteLine("\nPress (Y) or ENTER to confirm, (N) or ESC to cancel:");

		while (true)
		{
			ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
			if (keyInfo.Key == ConsoleKey.Y || keyInfo.Key == ConsoleKey.Enter)
			{
				return true;
			}
			else if (keyInfo.Key == ConsoleKey.N || keyInfo.Key == ConsoleKey.Escape)
			{
				return false;
			}
		}
	}

	static void HandleUserTransaction(VendingMachine6 vendingMachine, User6 user, int itemIndex, int quantity)
	{
		VendingMachineItem6 selectedItem = vendingMachine.GetItemByIndex(itemIndex);
		if (selectedItem != null)
		{
			// int quantity = GetQuantity();
			if (quantity > 0)
			{
				double totalCost = selectedItem.Price * quantity;
				if (user.HasEnoughBalance(totalCost))
				{
					if (vendingMachine.IsItemInStock(selectedItem, quantity))
					{
						if (ConfirmPurchase(selectedItem, user, quantity))
						{
							user.UpdateBalance(-totalCost);
							vendingMachine.UpdateStock(selectedItem, -quantity);
							DisplaySelectedItem(selectedItem, quantity, totalCost);
							Console.WriteLine($"Quantity purchased: {quantity}");
							Console.WriteLine($"Your remaining balance: ${user.Balance}");
						}
						else
						{
							Console.WriteLine("Purchase canceled.");
						}
					}
					else
					{
						Console.WriteLine("Sorry, not enough items in stock.");
					}
				}
				else
				{
					Console.WriteLine("Insufficient balance. Please try another item.");
				}
			}
		}
		else
		{
			Console.WriteLine("Invalid selection. Please try again.");
		}
	}
}