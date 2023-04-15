namespace VendingMachineApp.TaskFiles;

public class LessonTask
{
	public string Name { get; }
	public Action Action { get; }

	public LessonTask(string name, Action action)
	{
		Name = name;
		Action = action;
	}
}
