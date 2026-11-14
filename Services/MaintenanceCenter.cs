using MaintenanceCenter.Models;

namespace MaintenanceCenter.Services;

public class MaintenanceCenter
{
    private List<Device> _devices = new();

    public void AddDevice(Device device)
    {
        _devices.Add(device);
        device.OnStatusChanged += msg => Console.WriteLine($"[تنبيه] {msg}");
    }

    public void ShowAllDevices()
    {
        Console.WriteLine("\n=== جميع الأجهزة ===");
        foreach (var d in _devices)
        {
            d.ShowInfo();
            Console.WriteLine("---------------");
        }
    }

    public void RepairAll()
    {
        foreach (var d in _devices) d.Repair();
    }
}
