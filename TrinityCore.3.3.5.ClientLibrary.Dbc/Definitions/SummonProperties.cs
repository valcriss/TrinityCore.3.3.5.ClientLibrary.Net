using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("SummonProperties.dbc")]
public class SummonProperties : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Control { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int Faction { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Title { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int Slot { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    public FactionTemplate? GetFactionFactionTemplate()
    {
        return DbcDirectory.Open<FactionTemplate>()?.Where(c => c.Id == Faction).FirstOrDefault();
    }
}