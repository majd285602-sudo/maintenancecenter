using MaintenanceCenter.Models;
using MaintenanceCenter.Services;
using MaintenanceCenter.Utils;

var center = new MaintenanceCenter();

var fridge = new Refrigerator { Brand = "LG", Price = 1200, CapacityLiters = 350 };
var washer = new WashingMachine { Brand = "Samsung", Price = 900, LoadKg = 8 };
var ac = new AirConditioner { Brand = "Midea", Price = 700, PowerBTU = 12000 };

center.AddDevice(fridge);
center.AddDevice(washer);
center.AddDevice(ac);

center.ShowAllDevices();
center.RepairAll();

fridge.ChangeStatus("Under Repair");
Logger.Log("تمت عملية الصيانة");
