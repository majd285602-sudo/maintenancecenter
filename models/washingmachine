namespace MaintenanceCenter.Models;

public class WashingMachine : Device
{
    public int LoadKg { get; set; }

    public override decimal CalculateRepairCost() => Price * 0.12m + 40;
    public override void Repair() => Console.WriteLine($"تم إصلاح الغسالة {Brand} - الحمولة {LoadKg} كغ");

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"نوع: غسالة | حمولة: {LoadKg} كغ | تكلفة الإصلاح: {CalculateRepairCost()}");
    }
}
