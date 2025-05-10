using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("PetPersonality.dbc")]
public class PetPersonality : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? HappinessThreshold { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? HappinessDamage { get; set; }
}