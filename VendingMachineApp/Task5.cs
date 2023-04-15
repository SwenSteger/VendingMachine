/*
Task 5: Enhancing the user experience:

- After each purchase, display the user's remaining balance.
- Display the output using a separate method.
- Add error handling for invalid input, insufficient balance, or out-of-stock items.
- Allow the user to exit the application gracefully.
 */

using VendingMachineApp.TaskFiles.Task5;

namespace VendingMachineApp;

class Task5
{
	public static void Run()
	{
		VendingMachine5 vendingMachine = InitializeVendingMachine();
		User5 user = new User5(10);
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
					VendingMachineItem5 selectedItem = GetSelectedItem(vendingMachine, itemIndex);
					HandleUserTransaction(vendingMachine, user, selectedItem);
				}
				else
				{
					Console.WriteLine("Invalid selection. Please try again.");
				}
			}
		}
	}

	static VendingMachine5 InitializeVendingMachine()
	{
		List<VendingMachineItem5> items = new List<VendingMachineItem5>
		{
			new VendingMachineItem5("Coke", 1.5, 10),
			new VendingMachineItem5("Pepsi", 1.5, 10),
			new VendingMachineItem5("Water", 1.0, 10),
			new VendingMachineItem5("Chips", 0.5, 10),
			new VendingMachineItem5("Chocolate", 0.75, 10)
		};
		return new VendingMachine5(items);
	}

	static void DisplayMenu(VendingMachine5 vendingMachine)
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

	static void DisplaySelectedItem(VendingMachineItem5 selectedItem)
	{
		Console.WriteLine($"You have selected: {selectedItem.Name}, Price: ${selectedItem.Price}");
	}

	static VendingMachineItem5 GetSelectedItem(VendingMachine5 vendingMachine, int userInput)
	{
		return vendingMachine.Items[userInput];
	}

	static void HandleUserTransaction(VendingMachine5 vendingMachine, User5 user, VendingMachineItem5 selectedItem)
	{
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

}