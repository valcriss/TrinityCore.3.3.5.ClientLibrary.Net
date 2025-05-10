using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ScalingStatValues.dbc")]
public class ScalingStatValues : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Charlevel { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int ShoulderBudget { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int TrinketBudget { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int WeaponBudget1H { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int RangedBudget { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int ClothShoulderArmor { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int LeatherShoulderArmor { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int MailShoulderArmor { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int PlateShoulderArmor { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int WeaponDPS1H { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int WeaponDPS2H { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int SpellcasterDPS1H { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int SpellcasterDPS2H { get; set; }

    [DbcColumn(14, DbcColumnDataType.Int32)]
    public int RangedDPS { get; set; }

    [DbcColumn(15, DbcColumnDataType.Int32)]
    public int WandDPS { get; set; }

    [DbcColumn(16, DbcColumnDataType.Int32)]
    public int SpellPower { get; set; }

    [DbcColumn(17, DbcColumnDataType.Int32)]
    public int PrimaryBudget { get; set; }

    [DbcColumn(18, DbcColumnDataType.Int32)]
    public int TertiaryBudget { get; set; }

    [DbcColumn(19, DbcColumnDataType.Int32)]
    public int ClothCloakArmor { get; set; }

    [DbcColumn(20, DbcColumnDataType.Int32)]
    public int ClothChestArmor { get; set; }

    [DbcColumn(21, DbcColumnDataType.Int32)]
    public int LeatherChestArmor { get; set; }

    [DbcColumn(22, DbcColumnDataType.Int32)]
    public int MailChestArmor { get; set; }

    [DbcColumn(23, DbcColumnDataType.Int32)]
    public int PlateChestArmor { get; set; }
}