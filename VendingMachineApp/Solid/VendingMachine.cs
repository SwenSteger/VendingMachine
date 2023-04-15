using VendingMachineApp.Solid.Interfaces;

namespace VendingMachineApp.Solid;

internal class VendingMachine : IVendingMachine
{
	public IReadOnlyList<IVendingMachineItem> Items { get; private set; }

	public VendingMachine(List<IVendingMachineItem> items)
	{
		Items = items.AsReadOnly();
	}

	public IVendingMachineItem GetItemByIndex(int index)
	{
		if (index >= 0 && index < Items.Count)
		{
			return Items[index];
		}
		return null;
	}

	public bool IsItemInStock(IVendingMachineItem item, int quantity = 1)
	{
		return item.Stock > quantity;
	}

	public void UpdateStock(IVendingMachineItem item, int change)
	{
		item.Stock += change;
	}
}