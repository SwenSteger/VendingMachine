namespace VendingMachineApp.TaskFiles.Task6
{
	class VendingMachine6
	{
		public List<VendingMachineItem6> Items { get; private set; }

		public VendingMachine6(List<VendingMachineItem6> items)
		{
			Items = items;
		}

		public VendingMachineItem6 GetItemByName(string name)
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

		public bool IsItemInStock(VendingMachineItem6 item, int quantity = 1)
		{
			return item.Stock >= quantity;
		}

		public void UpdateStock(VendingMachineItem6 item, int change)
		{
			item.Stock += change;
		}

		public VendingMachineItem6 GetItemByIndex(int index)
		{
			if (index >= 0 && index < Items.Count)
			{
				return Items[index];
			}
			return null;
		}
	}
}
