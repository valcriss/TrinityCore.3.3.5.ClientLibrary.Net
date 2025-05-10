using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("BannedAddOns.dbc")]
public class BannedAddOns : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? NameMD5 { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? VersionMD5 { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int LastModified { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int Flags { get; set; }
}