using System;
using System.Collections.Generic;

// الفئة الأساسية
public class Device
{
    public string Brand = "";
    public string Model = "";
    public int Year;
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Brand: {Brand} | Model: {Model} | Year: {Year}");
    }
}

public class Refrigerator : Device
{
    public int Capacity;
    public override void DisplayInfo()
    {
        Console.WriteLine($"[براد] Brand: {Brand} | Model: {Model} | Year: {Year} | Capacity: {Capacity}L");
    }
}

public class WashingMachine : Device
{
    public int LoadCapacity;
    public override void DisplayInfo()
    {
        Console.WriteLine($"[غسالة] Brand: {Brand} | Model: {Model} | Year: {Year} | Load: {LoadCapacity}kg");
    }
}

public class AirConditioner : Device
{
    public int Power;
    public override void DisplayInfo()
    {
        Console.WriteLine($"[مكيف] Brand: {Brand} | Model: {Model} | Year: {Year} | Power: {Power} BTU");
    }
}

public class MaintenanceCenter
{
    public List<Device> Devices = new List<Device>();
    public void AddDevice(Device d) { Devices.Add(d); }
    public void ShowAll()
    {
        Console.WriteLine("\n--- All Devices ---");
        if (Devices.Count == 0) Console.WriteLine("No devices yet");
        foreach (var d in Devices) d.DisplayInfo();
    }
}

class Program
{
    static void Main()
    {
        MaintenanceCenter center = new MaintenanceCenter();

        center.AddDevice(new Refrigerator { Brand = "LG", Model = "GR-500", Year = 2022, Capacity = 450 });
        center.AddDevice(new WashingMachine { Brand = "Samsung", Model = "WF-800", Year = 2023, LoadCapacity = 8 });
        center.AddDevice(new AirConditioner { Brand = "Midea", Model = "MS-12000", Year = 2024, Power = 12000 });

        while (true)
        {
            Console.WriteLine("\n=== Maintenance Center ===");
            Console.WriteLine("1. Add Refrigerator");
            Console.WriteLine("2. Show All Devices");
            Console.WriteLine("3. Exit");
            Console.Write("Choose: ");
            string choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                Console.Write("Brand: "); string b = Console.ReadLine() ?? "";
                Console.Write("Model: "); string m = Console.ReadLine() ?? "";
                center.AddDevice(new Refrigerator { Brand = b, Model = m, Year = 2024, Capacity = 300 });
                Console.WriteLine("Added Successfully!");
            }
            else if (choice == "2")
            {
                center.ShowAll();
            }
            else if (choice == "3")
            {
                break;
            }
        }
    }
}
