namespace VendingMachineApp.TaskFiles.Task5;

class VendingMachine5
{
	public List<VendingMachineItem5> Items { get; private set; }

	public VendingMachine5(List<VendingMachineItem5> items)
	{
		Items = items;
	}

	public VendingMachineItem5 GetItemByName(string name)
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
    
	public bool IsItemInStock(VendingMachineItem5 item)
	{
		return item.Stock > 0;
	}

	public void UpdateStock(VendingMachineItem5 item, int change)
	{
		item.Stock += change;
	}
}