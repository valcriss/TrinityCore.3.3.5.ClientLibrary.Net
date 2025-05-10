using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("LightIntBand.dbc")]
    public class LightIntBand : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Num { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 16)]
        public int[]? Time { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfUint32, 16)]
        public int[]? Data { get; set; }

     }
}
