using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Cfg_Configs.dbc")]
public class CfgConfigs : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int RealmType { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int PlayerKillingAllowed { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Roleplaying { get; set; }
}