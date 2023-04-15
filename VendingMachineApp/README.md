# VendingMachineApp
### C# LessonTasks reference and example-code

This project is just a simple console application that simulates a vending machine. It is meant to be a simple project that can be used to practice the concepts learned in the C# lessons.
The gradual learning process throughout these tasks is meant to help you practice the concepts learned in the lessons and to help you build a solid foundation for your C# skills.

**Task 0: Setting up the project**
- Create a new console application project in Visual Studio.


**Task 1: Creating a simple menu with items to purchase in the main method**

- Initialize a list of available items and their prices.
- Display the menu to the user.
- Prompt the user to enter their choice.
- Display the selected item and its price.
- Repeat until the user exits.


**Task 2: Refactoring the code with separate methods**

- Consider using a Dictionary<string, double> to store the items and their prices.
- Create methods for displaying the menu, handling user input, and displaying the output.
- Use an index for the menu item selection instead of the item name.
- Try to use TryParse for validating user input and handling potential errors.
- Call these methods in the main method.


**Task 3: Creating classes for User, VendingMachineItem, and VendingMachine**

- Create a VendingMachineItem class with properties for name and price.
- Create a VendingMachine class that holds a list of VendingMachineItem objects and a quantity of stock for a given item.
- Update the main method to use these new classes.


**Task 4: Adding methods for transactions and stock management**

- Create a User class with a property for tracking the user's balance.
- Add methods to the User class for modifying the balance upon a transaction and verifying if the user has enough balance to purchase an item.
- Add methods to the VendingMachine class for removing from the quantity upon a successful purchase and updating the list to display remaining stock.
- Update the main method to call these methods when a user makes a purchase.


**Task 5: Enhancing the user experience**

- After each purchase, display the user's remaining balance.
- Display the output using a separate method.
- Add error handling for invalid input, insufficient balance, or out-of-stock items.
- Allow the user to exit the application gracefully.


**Task 6: Enhance the purchase process with quantity and confirmation**

- Update the purchase process to prompt the user for the quantity of items to purchase after selecting an item by index.
- Use Console.ReadKey to accept quantity input from 1-9, with 1 as the default if the user presses ENTER, and cancel the transaction if the user presses ESC.
- Add a confirmation dialog after the user picks a quantity, displaying a summary of the chosen item, quantity, and total cost.
- Allow the user to confirm or cancel the purchase using Y/N or ENTER/ESC.
- Update the VendingMachine class and methods accordingly to handle the new purchase process and quantity management.
