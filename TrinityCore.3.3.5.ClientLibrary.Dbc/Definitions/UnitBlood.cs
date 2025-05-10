using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("UnitBlood.dbc")]
    public class UnitBlood : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.ArrayOfUint32, 2)]
        public int[]? CombatBloodSpurtFront { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 2)]
        public int[]? CombatBloodSpurtBack { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfStringRef, 5)]
        public string[]? GroundBlood { get; set; }

     }
}
