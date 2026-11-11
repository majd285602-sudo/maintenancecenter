namespace MaintenanceCenter.Interfaces;

public interface IRepairable
{
    void Repair();
    decimal CalculateRepairCost();
}
