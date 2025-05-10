using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("TaxiNodes.dbc")]
public class TaxiNodes : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ContinentId { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? Pos { get; set; }

    [DbcColumn(3, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? MountCreatureId { get; set; }

    public Map? GetContinentIdMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == ContinentId).FirstOrDefault();
    }
}