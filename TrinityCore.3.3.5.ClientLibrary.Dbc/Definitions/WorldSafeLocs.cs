using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("WorldSafeLocs.dbc")]
public class WorldSafeLocs : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Continent { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? Loc { get; set; }

    [DbcColumn(3, DbcColumnDataType.Loc)]
    public string? AreaNameLang { get; set; }

    public Map? GetContinentMap()
    {
        return DbcDirectory.Open<Map>()?.Where(c => c.Id == Continent).FirstOrDefault();
    }
}