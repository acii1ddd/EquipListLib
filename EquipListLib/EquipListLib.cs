using System.Runtime.InteropServices;

namespace EquipListLib;

public static class EquipListLib
{
    [UnmanagedCallersOnly(EntryPoint = "add")]
    public static int Add(int a, int b) =>  a + b;
}

public class EquipmentItem
{
    public int DepartmentId { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
    
    public decimal TotalPrice { get; set; }
}