namespace MaintenanceCenter.Utils;

public static class Logger
{
    public static int TotalRepairs { get; private set; } = 0;

    public static void Log(string message)
    {
        TotalRepairs++;
        Console.WriteLine($"[LOG] {message} - إجمالي الإصلاحات: {TotalRepairs}");
    }
}
