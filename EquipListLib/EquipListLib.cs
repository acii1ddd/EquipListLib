using System.Runtime.InteropServices;

namespace EquipListLib;

public static class EquipListLib
{
    [UnmanagedCallersOnly(EntryPoint = "add")]
    public static int Add(int a, int b) =>  a + b;
}