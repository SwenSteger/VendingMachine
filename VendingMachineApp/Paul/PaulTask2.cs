﻿namespace VendingMachineApp.Paul;

public class PaulTask2
{
	#region SUGGESTED IMPROVEMENTS
	
	// Avoid nesting switch statements
	// Use dictionaries to store data
	// Use methods to break up code into logical chunks
	
	static void DisplayMenu()
	{
		// Print menu to screen
	}

	static void HandleUserInput()
	{
		// Deal with user input
	}

	static void DisplayResponse()
	{
		// Display user-choice response
	}
	
	#endregion
	
	public static void Run()
	{
		bool showMenu = true;
		while (showMenu)
		{
			showMenu = MainMenu();
		}
	}
	
	public static bool MainMenu()
	{
		Console.WriteLine("Welcome in our Vending Machine !!!.");
		Console.WriteLine("\n Make a choice please.\n Enter a number from 0 to 9\n");
		Console.WriteLine("1 ). PEPSI 0.250ml / Price : 1.10 e");
		Console.WriteLine("2 ). COLA 0.250ml / Price : 1.20 e");
		Console.WriteLine("3 ). FANTA 0.250ml / Price : 1.50 e");
		Console.WriteLine("4 ). BAVARIA 0.250ml / Price : 2.00 e");
		Console.WriteLine("5 ). BAVARIA 0.500ml / Price : 3.30 e");
		Console.WriteLine("6 ). HEINEKEN 0.250ml / Price : 3.45 e");
		Console.WriteLine("7 ). HERTOG 0.250ml / Price : 4.50 e");
		Console.WriteLine("8 ). HERTOG 0.500ml / Price : 6.50 e");
		Console.WriteLine("9 ). WINE 0.250ml / Price : 7.50 e");
		Console.WriteLine("0 ). Exit");
		switch (Console.ReadLine())
		{
			case "1":
				Console.WriteLine("Thank you for buying PEPSI 0.250ml");
				Console.WriteLine("\n Please:\n");
				Console.WriteLine(value: " 1.10");
				Console.WriteLine("Something else y/n?");
				switch (Console.ReadLine())
				{
					case "y":
						return true;
					case "n":
						Console.WriteLine("Come Back!");
						return false;
				}
				return true;
			case "2":
				Console.WriteLine("thank you for buying COLA 0.250ml");
				Console.WriteLine("\n Please.");
				Console.WriteLine(value: "1.20");
				Console.WriteLine("Something else y/n?");
				switch (Console.ReadLine())
				{
					case "y":
						return true;
					case "n":
						Console.WriteLine("Come Back!");
						return false;
				}
				return true;
			case "3":
				Console.WriteLine("thank you for buying FANTA 0.250ml");
				Console.WriteLine("\n Please.");
				Console.WriteLine(value: "1.50");
				Console.WriteLine("Something else y/n?");
				switch (Console.ReadLine())
				{
					case "y":
						return true;
					case "n":
						Console.WriteLine("Come Back!");
						return false;
				}
				return true;
			case "4":
				Console.WriteLine("thank you for buying BAVARIA 0.250ml");
				Console.WriteLine("\nPlease.");
				Console.WriteLine(value: "2.00");
				Console.WriteLine("Something else y/n?");
				switch (Console.ReadLine())
				{
					case "y":
						return true;
					case "n":
						Console.WriteLine("Come Back!");
						return false;
				}
				return true;
			case "5":
				Console.WriteLine("thank you for buying BAVARIA 0.500ml");
				Console.WriteLine("\nPlease.");
				Console.WriteLine(value: "3.30");
				Console.WriteLine("Something else y/n?");
				switch (Console.ReadLine())
				{
					case "y":
						return true;
					case "n":
						Console.WriteLine("Come Back!");
						return false;
				}
				return true;
			case "6":
				Console.WriteLine("thank you for buying HEINEKEN 0.250ml");
				Console.WriteLine("\nPlease.");
				Console.WriteLine(value: "3.45");
				Console.WriteLine("Something else y/n?");
				switch (Console.ReadLine())
				{
					case "y":
						return true;
					case "n":
						Console.WriteLine("Come Back!");
						return false;
				}
				return true;
			case "7":
				Console.WriteLine("thank you for buying HERTOG 0.250ml");
				Console.WriteLine("\nPlease.");
				Console.WriteLine(value: "4.50");
				Console.WriteLine("Something else y/n?");
				switch (Console.ReadLine())
				{
					case "y":
						return true;
					case "n":
						Console.WriteLine("Come Back!");
						return false;
				}
				return true;
			case "8":
				Console.WriteLine("thank you for buying HERTOG 0.500ml");
				Console.WriteLine("\nPlease.");
				Console.WriteLine(value: "6.50");
				Console.WriteLine("Something else y/n?");
				switch (Console.ReadLine())
				{
					case "y":
						return true;
					case "n":
						Console.WriteLine("Come Back!");
						return false;
				}
				return true;
			case "9":
				Console.WriteLine("thank you for buying WINE 0.250ml");
				Console.WriteLine("\nPlease.");
				Console.WriteLine(value: "7.50");
				Console.WriteLine("Something else y/n?");
				switch (Console.ReadLine())
				{
					case "y":
						return true;
					case "n":
						Console.WriteLine("Come Back!");
						return false;
				}
				return true;
			default:
				Console.WriteLine("Come Back!");
				return false;
		}
	}
}