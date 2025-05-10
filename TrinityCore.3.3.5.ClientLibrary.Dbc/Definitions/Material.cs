using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Material.dbc")]
public class Material : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int FoleySoundId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int SheatheSoundId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int UnsheatheSoundId { get; set; }
}