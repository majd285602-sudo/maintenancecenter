using MaintenanceCenter.Interfaces;

namespace MaintenanceCenter.Models;

public abstract class Device : IRepairable
{
    private string _brand = "";
    private decimal _price;

    public string Brand 
    { 
        get => _brand; 
        set => _brand = string.IsNullOrWhiteSpace(value) ? "Unknown" : value; 
    }
    public decimal Price 
    { 
        get => _price; 
        set => _price = value < 0 ? 0 : value; 
    }

    public string Status { get; set; } = "New";

    // حدث + تفويض
    public delegate void StatusChangedHandler(string message);
    public event StatusChangedHandler? OnStatusChanged;

    protected void Notify(string message)
    {
        OnStatusChanged?.Invoke(message);
    }

    public void ChangeStatus(string newStatus)
    {
        Status = newStatus;
        Notify($"تم تغيير حالة جهاز {Brand} إلى {newStatus}");
    }

    public abstract decimal CalculateRepairCost();
    public abstract void Repair();

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Brand: {Brand} | Price: {Price} | Status: {Status}");
    }
}
