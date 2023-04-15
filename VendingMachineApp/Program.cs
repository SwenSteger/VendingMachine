using VendingMachineApp.Paul;
using VendingMachineApp.TaskFiles;

namespace VendingMachineApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var tasks = new List<LessonTask>
			{
				new LessonTask("Task 1", Task1.Run),
				new LessonTask("Task 2", Task2.Run),
				new LessonTask("Task 3", Task3.Run),
				new LessonTask("Task 4", Task4.Run),
				new LessonTask("Task 5", Task5.Run),
				new LessonTask("Task 6", Task6.Run),
				new LessonTask("Paul's Task 1", PaulTask1.Run),
				new LessonTask("Paul's Task 2", PaulTask2.Run),
				new LessonTask("Example SOLID", ExampleSolid.Run)
			};

			var exit = false;
			while (!exit)
			{
				DisplayMenu(tasks);
				string userInput = GetUserInput();

				if (userInput.ToLower() == "exit")
				{
					exit = true;
				}
				else if (int.TryParse(userInput, out var selectedIndex))
				{
					if (selectedIndex >= 1 && selectedIndex <= tasks.Count)
					{
						LessonTask selectedLessonTask = tasks[selectedIndex - 1];
						selectedLessonTask.Action();

						Console.Clear();
					}
				}
			}
		}

		private static void DisplayMenu(IReadOnlyList<LessonTask> tasks)
		{
			Console.WriteLine("Task Menu:");
			for (var i = 0; i < tasks.Count; i++)
			{
				Console.WriteLine($"{i + 1}. {tasks[i].Name}");
			}
			Console.WriteLine("\nEnter the task number to run or type 'exit' to quit:");
		}

		private static string GetUserInput()
		{
			return Console.ReadLine();
		}
	}

}

