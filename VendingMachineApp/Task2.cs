/*
Task 2: Refactoring the code with separate methods

- Consider using a Dictionary<string, double> to store the items and their prices.
- Create methods for displaying the menu, handling user input, and displaying the output.
- Use an index for the menu item selection instead of the item name.
- Try to use TryParse for validating user input and handling potential errors.
- Call these methods in the main method.
 */

namespace VendingMachineApp;

public class Task2
{
	public static void Run()
	{
		Dictionary<string, double> items = InitializeItems();
		while (true)
		{
			DisplayMenu(items);
			int userInput = GetUserInput(items.Count);

			if (userInput == -1)
			{
				break;
			}

			string selectedItem = GetSelectedItem(items, userInput);
			if (selectedItem != null)
			{
				DisplaySelectedItem(selectedItem, items[selectedItem]);
			}
			else
			{
				Console.WriteLine("Invalid selection. Please try again.");
			}
		}
	}

	static Dictionary<string, double> InitializeItems()
	{
		return new Dictionary<string, double>
		{
			{ "Coke", 1.5 },
			{ "Pepsi", 1.5 },
			{ "Water", 1.0 },
			{ "Chips", 0.5 },
			{ "Chocolate", 0.75 }
		};
	}

	static void DisplayMenu(Dictionary<string, double> items)
	{
		Console.WriteLine("\nVending Machine Menu:");
		int index = 1;
		foreach (var item in items)
		{
			Console.WriteLine($"{index} - {item.Key} - ${item.Value}");
			index++;
		}
	}

	static int GetUserInput(int maxIndex)
	{
		Console.WriteLine("Enter the item number to purchase or type 'exit' to quit:");
		string userInput = Console.ReadLine();

		if (userInput.ToLower() == "exit")
		{
			return -1;
		}

		if (int.TryParse(userInput, out int selection))
		{
			if (selection >= 1 && selection <= maxIndex)
			{
				return selection;
			}
		}

		Console.WriteLine("Invalid selection. Please try again.");
		return GetUserInput(maxIndex);
	}

	static string GetSelectedItem(Dictionary<string, double> items, int userInput)
	{
		int index = 1;
		foreach (var item in items)
		{
			if (index == userInput)
			{
				return item.Key;
			}
			index++;
		}
		return null;
	}

	static void DisplaySelectedItem(string itemName, double itemPrice)
	{
		Console.WriteLine($"You have selected: {itemName}, Price: ${itemPrice}");
	}
}