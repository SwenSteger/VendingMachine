/*
Task 1: Creating a simple menu with items to purchase in the main method:

- Initialize a list or array of available items and their prices. 
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
		var names = new string[] { "Coke", "Pepsi", "Water", "Chips", "Chocolate" };
		var prices = new double[] { 1.5, 1.5, 1.0, 0.5, 0.75 };

		while (true)
		{
			Console.WriteLine("\nVending Machine Menu:");
			for (int i = 0; i < names.Length; i++)
			{
				Console.WriteLine($"{names[i]} - ${prices[i]}");
			}

			Console.WriteLine("Enter the item name to purchase or type 'exit' to quit:");
			string userInput = Console.ReadLine();

			if (userInput.ToLower() == "exit")
			{
				break;
			}

			if (names.Contains(userInput))
			{
				var index = Array.IndexOf(names, userInput);
				Console.WriteLine($"You have selected: {userInput}, Price: ${prices[index]}");
			}
			else
			{
				Console.WriteLine("Invalid selection. Please try again.");
			}
		}
	}
}
