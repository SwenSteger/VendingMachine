namespace VendingMachineApp.TaskFiles.Task4;

class VendingMachine4
{
	public List<VendingMachineItem4> Items { get; private set; }

	public VendingMachine4(List<VendingMachineItem4> items)
	{
		Items = items;
	}

	public VendingMachineItem4 GetItemByName(string name)
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
    
	public bool IsItemInStock(VendingMachineItem4 item)
	{
		return item.Stock > 0;
	}

	public void UpdateStock(VendingMachineItem4 item, int change)
	{
		item.Stock += change;
	}
}