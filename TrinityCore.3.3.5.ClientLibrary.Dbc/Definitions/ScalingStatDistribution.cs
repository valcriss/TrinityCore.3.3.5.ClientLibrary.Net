using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ScalingStatDistribution.dbc")]
    public class ScalingStatDistribution : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.ArrayOfUint32, 10)]
        public int[]? StatId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 10)]
        public int[]? Bonus { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int Maxlevel { get; set; }

     }
}
