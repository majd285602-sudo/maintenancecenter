namespace MaintenanceCenter.Models;

public class AirConditioner : Device
{
    public int PowerBTU { get; set; }

    public override decimal CalculateRepairCost() => Price * 0.20m + 80;
    public override void Repair() => Console.WriteLine($"تم إصلاح المكيف {Brand} - القدرة {PowerBTU} BTU");

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"نوع: مكيف | قدرة: {PowerBTU} BTU | تكلفة الإصلاح: {CalculateRepairCost()}");
    }
}
