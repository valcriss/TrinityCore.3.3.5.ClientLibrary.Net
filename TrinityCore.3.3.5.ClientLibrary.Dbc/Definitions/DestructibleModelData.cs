using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("DestructibleModelData.dbc")]
    public class DestructibleModelData : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int State0ImpactEffectDoodadSet { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int State0AmbientDoodadSet { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int State1WMO { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int State1DestructionDoodadSet { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int State1ImpactEffectDoodadSet { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int State1AmbientDoodadSet { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int State2WMO { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int State2DestructionDoodadSet { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int State2ImpactEffectDoodadSet { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int State2AmbientDoodadSet { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int State3WMO { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int State3InitDoodadSet { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int State3AmbientDoodadSet { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Int32)]
        public int EjectDirection { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.Int32)]
        public int RepairGroundFx { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.Int32)]
        public int DoNotHighlight { get; set; }

        [DbcColumn(17, Enums.DbcColumnDataType.Int32)]
        public int HealEffect { get; set; }

        [DbcColumn(18, Enums.DbcColumnDataType.Int32)]
        public int HealEffectSpeed { get; set; }

     }
}
