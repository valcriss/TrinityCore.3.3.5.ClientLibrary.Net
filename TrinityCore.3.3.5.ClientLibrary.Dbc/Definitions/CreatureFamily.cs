using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("CreatureFamily.dbc")]
public class CreatureFamily : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Float)]
    public float MinScale { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int MinScaleLevel { get; set; }

    [DbcColumn(3, DbcColumnDataType.Float)]
    public float MaxScale { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int MaxScaleLevel { get; set; }

    [DbcColumn(5, DbcColumnDataType.ArrayOfUint32, 2)]
    public int[]? SkillLine { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int PetFoodMask { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int PetTalentType { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int CategoryEnumId { get; set; }

    [DbcColumn(9, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(10, DbcColumnDataType.StringRef)]
    public string? IconFile { get; set; }

    public SkillLine[]? GetSkillLineSkillLines()
    {
        return DbcDirectory.Open<SkillLine>()?.Where(c => SkillLine != null && SkillLine.Contains(c.Id)).ToArray();
    }
}