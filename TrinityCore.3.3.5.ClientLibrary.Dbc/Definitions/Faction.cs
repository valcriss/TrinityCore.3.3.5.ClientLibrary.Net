using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Faction.dbc")]
public class Faction : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int ReputationIndex { get; set; }

    [DbcColumn(2, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? ReputationRaceMask { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? ReputationClassMask { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? ReputationBase { get; set; }

    [DbcColumn(5, DbcColumnDataType.ArrayOfUint32, 4)]
    public int[]? ReputationFlags { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int ParentFactionId { get; set; }

    [DbcColumn(7, DbcColumnDataType.ArrayOfFloat, 2)]
    public float[]? ParentFactionMod { get; set; }

    [DbcColumn(8, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? ParentFactionCap { get; set; }

    [DbcColumn(9, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(10, DbcColumnDataType.Loc)]
    public string? Description { get; set; }

    public Faction? GetParentFactionIdFaction()
    {
        return DbcDirectory.Open<Faction>()?.Where(c => c.Id == ParentFactionId).FirstOrDefault();
    }
}