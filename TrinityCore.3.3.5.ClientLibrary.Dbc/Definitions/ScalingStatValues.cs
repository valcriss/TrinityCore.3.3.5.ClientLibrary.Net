using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ScalingStatValues.dbc")]
    public class ScalingStatValues : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Charlevel { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int ShoulderBudget { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int TrinketBudget { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int WeaponBudget1H { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int RangedBudget { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int ClothShoulderArmor { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int LeatherShoulderArmor { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int MailShoulderArmor { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int PlateShoulderArmor { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int WeaponDPS1H { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int WeaponDPS2H { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int SpellcasterDPS1H { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int SpellcasterDPS2H { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Int32)]
        public int RangedDPS { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.Int32)]
        public int WandDPS { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.Int32)]
        public int SpellPower { get; set; }

        [DbcColumn(17, Enums.DbcColumnDataType.Int32)]
        public int PrimaryBudget { get; set; }

        [DbcColumn(18, Enums.DbcColumnDataType.Int32)]
        public int TertiaryBudget { get; set; }

        [DbcColumn(19, Enums.DbcColumnDataType.Int32)]
        public int ClothCloakArmor { get; set; }

        [DbcColumn(20, Enums.DbcColumnDataType.Int32)]
        public int ClothChestArmor { get; set; }

        [DbcColumn(21, Enums.DbcColumnDataType.Int32)]
        public int LeatherChestArmor { get; set; }

        [DbcColumn(22, Enums.DbcColumnDataType.Int32)]
        public int MailChestArmor { get; set; }

        [DbcColumn(23, Enums.DbcColumnDataType.Int32)]
        public int PlateChestArmor { get; set; }

     }
}
