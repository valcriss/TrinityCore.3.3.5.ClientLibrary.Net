using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ParticleColor.dbc")]
    public class ParticleColor : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.ArrayOfUint32, 3)]
        public int[]? Start { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 3)]
        public int[]? MId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfUint32, 3)]
        public int[]? End { get; set; }

     }
}
