using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("CreatureDisplayInfoExtra.dbc")]
public class CreatureDisplayInfoExtra : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int DisplayRaceId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int DisplaySexId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int SkinId { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int FaceId { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int HairStyleId { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int HairColorId { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int FacialHairId { get; set; }

    [DbcColumn(8, DbcColumnDataType.ArrayOfUint32, 11)]
    public int[]? NPCItemDisplay { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(10, DbcColumnDataType.StringRef)]
    public string? BakeName { get; set; }

    public ChrRaces? GetDisplayRaceIdChrRaces()
    {
        return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == DisplayRaceId).FirstOrDefault();
    }

    public ItemDisplayInfo[]? GetNPCItemDisplayItemDisplayInfos()
    {
        return DbcDirectory.Open<ItemDisplayInfo>()?.Where(c => NPCItemDisplay != null && NPCItemDisplay.Contains(c.Id)).ToArray();
    }
}