/*
Task 1: Creating a simple menu with items to purchase in the main method:

- Initialize a list of available items and their prices. 
- Display the menu to the user.
- Prompt the user to enter their choice.
- Display the selected item and its price.
- Repeat until the user exits.
 */

namespace VendingMachineApp;

public class Task1
{
	public static void Run()
	{
		Dictionary<string, double> items = new Dictionary<string, double>
		{
			{ "Coke", 1.5 },
			{ "Pepsi", 1.5 },
			{ "Water", 1.0 },
			{ "Chips", 0.5 },
			{ "Chocolate", 0.75 }
		};

		while (true)
		{
			Console.WriteLine("\nVending Machine Menu:");
			foreach (var item in items)
			{
				Console.WriteLine($"{item.Key} - ${item.Value}");
			}

			Console.WriteLine("Enter the item name to purchase or type 'exit' to quit:");
			string userInput = Console.ReadLine();

			if (userInput.ToLower() == "exit")
			{
				break;
			}

			if (items.ContainsKey(userInput))
			{
				Console.WriteLine($"You have selected: {userInput}, Price: ${items[userInput]}");
			}
			else
			{
				Console.WriteLine("Invalid selection. Please try again.");
			}
		}
	}
}