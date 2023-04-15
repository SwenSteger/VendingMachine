using VendingMachineApp.Solid.Interfaces;

namespace VendingMachineApp.Solid;

internal class Menu : IMenu
{
	private readonly IVendingMachine _vendingMachine;
	private readonly IUser _user;

	public Menu(IVendingMachine vendingMachine, IUser user)
	{
		_vendingMachine = vendingMachine;
		_user = user;
	}

	public void Display()
	{
		bool continueLoop = true;

		while (continueLoop)
		{
			DisplayMenu(_vendingMachine);
			string userInput = GetUserInput();

			if (userInput.ToLower() == "exit")
			{
				continueLoop = false;
			}
			else
			{
				int itemIndex;
				if (int.TryParse(userInput, out itemIndex))
				{
					int quantity = GetQuantity();
					if (quantity > 0)
					{
						HandleUserTransaction(_vendingMachine, _user, itemIndex - 1, quantity);
					}
					else
					{
						Console.WriteLine("Transaction cancelled.");
					}
				}
			}
		}
	}

	private void DisplayMenu(IVendingMachine vendingMachine)
	{
		Console.WriteLine("\nVending Machine Menu:");
		for (int i = 0; i < vendingMachine.Items.Count; i++)
		{
			var item = vendingMachine.Items[i];
			Console.WriteLine($"{i + 1}. {item.Name} - ${item.Price}");
		}
		Console.WriteLine($"Current blanace: {_user.Balance}");
	}

	private string GetUserInput()
	{
		Console.WriteLine("Enter the item number to purchase or type 'exit' to quit:");
		return Console.ReadLine();
	}
	
	private int GetQuantity()
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

	private void DisplaySelectedItem(IVendingMachineItem selectedItem, int quantity, double totalPrice)
	{
		Console.WriteLine($"You have selected {quantity} units of {selectedItem.Name}, Price: ${totalPrice}");
	}

	private bool ConfirmPurchase(IVendingMachineItem selectedItem, IUser user, int quantity)
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

	private void HandleUserTransaction(IVendingMachine vendingMachine, IUser user, int itemIndex, int quantity)
	{
		var selectedItem = vendingMachine.GetItemByIndex(itemIndex);
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