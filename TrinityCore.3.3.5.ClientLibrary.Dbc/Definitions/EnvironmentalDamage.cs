using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("EnvironmentalDamage.dbc")]
public class EnvironmentalDamage : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int EnumId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int VisualkitId { get; set; }

    public SpellVisualKit? GetVisualkitIdSpellVisualKit()
    {
        return DbcDirectory.Open<SpellVisualKit>()?.Where(c => c.Id == VisualkitId).FirstOrDefault();
    }
}