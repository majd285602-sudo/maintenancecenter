namespace MaintenanceCenter.Models;

public class Refrigerator : Device
{
    public int CapacityLiters { get; set; }

    public override decimal CalculateRepairCost() => Price * 0.15m + 50;
    public override void Repair() => Console.WriteLine($"تم إصلاح البراد {Brand} - السعة {CapacityLiters} لتر");

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"نوع: براد | سعة: {CapacityLiters} لتر | تكلفة الإصلاح: {CalculateRepairCost()}");
    }
}
