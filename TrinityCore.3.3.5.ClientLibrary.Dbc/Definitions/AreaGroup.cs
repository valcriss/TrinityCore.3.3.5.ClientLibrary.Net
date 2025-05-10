using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("AreaGroup.dbc")]
public class AreaGroup : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.ArrayOfUint32, 6)]
    public int[]? AreaId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int NextAreaId { get; set; }

    public AreaTable[]? GetAreaIdAreaTables()
    {
        return DbcDirectory.Open<AreaTable>()?.Where(c => AreaId != null && AreaId.Contains(c.Id)).ToArray();
    }

    public AreaGroup? GetNextAreaIdAreaGroup()
    {
        return DbcDirectory.Open<AreaGroup>()?.Where(c => c.Id == NextAreaId).FirstOrDefault();
    }
}