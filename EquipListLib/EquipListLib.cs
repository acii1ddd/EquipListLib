using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EquipListLib;

public static class EquipListLib
{
    private static readonly List<EquipmentItem> Items = [];

    [UnmanagedCallersOnly(EntryPoint = "get_all_json")]
    public static IntPtr GetAll()
    {
        var json = JsonSerializer.Serialize(Items, 
            EquipmentItemJsonContext.Default.ListEquipmentItem);
        
        return Marshal.StringToHGlobalUni(json);
    }
    
    static EquipListLib()
    {
        Items.Add(new EquipmentItem
        {
            Id = Guid.NewGuid(),
            DepartmentId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Осциллограф Tektronix TBS1102B",
            Quantity = 2,
            UnitPrice = 1200.00m,
        });

        Items.Add(new EquipmentItem
        {
            Id = Guid.NewGuid(),
            DepartmentId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "Мультиметр UNI-T UT61E",
            Quantity = 5,
            UnitPrice = 85.50m,
        });

        Items.Add(new EquipmentItem
        {
            Id = Guid.NewGuid(),
            DepartmentId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Name = "Лабораторный источник питания RIGOL DP832",
            Quantity = 1,
            UnitPrice = 650.00m,
        });
    }

}

[JsonSerializable(typeof(List<EquipmentItem>))]
[JsonSourceGenerationOptions(WriteIndented = false)]
internal partial class EquipmentItemJsonContext 
    : JsonSerializerContext
{
}

public class EquipmentItem
{
    public Guid Id { get; set; }
    
    public Guid DepartmentId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public int Quantity { get; set; }
    
    public decimal UnitPrice { get; set; }
    
    public decimal TotalPrice => UnitPrice * Quantity;
}