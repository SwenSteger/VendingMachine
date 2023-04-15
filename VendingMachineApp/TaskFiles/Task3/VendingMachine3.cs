namespace VendingMachineApp.TaskFiles.Task3;

class VendingMachine3
{
	public List<VendingMachineItem3> Items { get; private set; }

	public VendingMachine3(List<VendingMachineItem3> items)
	{
		Items = items;
	}

	public VendingMachineItem3 GetItemByName(string name)
	{
		foreach (var item in Items)
		{
			if (item.Name.ToLower() == name.ToLower())
			{
				return item;
			}
		}
		return null;
	}
}