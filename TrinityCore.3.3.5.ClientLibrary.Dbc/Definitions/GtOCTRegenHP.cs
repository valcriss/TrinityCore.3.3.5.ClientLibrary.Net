using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("gtOCTRegenHP.dbc")]
public class GtOCTRegenHP : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Float)]
    public float Data { get; set; }
}