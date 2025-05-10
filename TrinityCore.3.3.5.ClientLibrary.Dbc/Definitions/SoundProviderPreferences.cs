using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SoundProviderPreferences.dbc")]
    public class SoundProviderPreferences : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? Description { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int EAXEnvironmentSelection { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float EAXDecayTime { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Float)]
        public float EAX2EnvironmentSize { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Float)]
        public float EAX2EnvironmentDiffusion { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int EAX2Room { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int EAX2RoomHF { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Float)]
        public float EAX2DecayHFRatio { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int EAX2Reflections { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Float)]
        public float EAX2ReflectionsDelay { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int EAX2Reverb { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Float)]
        public float EAX2ReverbDelay { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Float)]
        public float EAX2RoomRolloff { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.Float)]
        public float EAX2AirAbsorption { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.Int32)]
        public int EAX3RoomLF { get; set; }

        [DbcColumn(17, Enums.DbcColumnDataType.Float)]
        public float EAX3DecayLFRatio { get; set; }

        [DbcColumn(18, Enums.DbcColumnDataType.Float)]
        public float EAX3EchoTime { get; set; }

        [DbcColumn(19, Enums.DbcColumnDataType.Float)]
        public float EAX3EchoDepth { get; set; }

        [DbcColumn(20, Enums.DbcColumnDataType.Float)]
        public float EAX3ModulationTime { get; set; }

        [DbcColumn(21, Enums.DbcColumnDataType.Float)]
        public float EAX3ModulationDepth { get; set; }

        [DbcColumn(22, Enums.DbcColumnDataType.Float)]
        public float EAX3HFReference { get; set; }

        [DbcColumn(23, Enums.DbcColumnDataType.Float)]
        public float EAX3LFReference { get; set; }

     }
}
