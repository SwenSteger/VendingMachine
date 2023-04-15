namespace VendingMachineApp.Solid.Interfaces;

public interface IVendingMachine
{
	IReadOnlyList<IVendingMachineItem> Items { get; }
	IVendingMachineItem GetItemByIndex(int index);
	bool IsItemInStock(IVendingMachineItem item, int quantity = 1);
	void UpdateStock(IVendingMachineItem item, int change);
}