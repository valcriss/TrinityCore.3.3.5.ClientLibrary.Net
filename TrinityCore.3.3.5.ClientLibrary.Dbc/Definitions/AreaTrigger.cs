using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("AreaTrigger.dbc")]
    public class AreaTrigger : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int ContinentId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? Pos { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Float)]
        public float Radius { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float BoxLength { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Float)]
        public float BoxWidth { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Float)]
        public float BoxHeight { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Float)]
        public float BoxYaw { get; set; }

        public Map? GetContinentIdMap()
        {
               return DbcDirectory.Open<Map>()?.Where(c => c.Id == this.ContinentId).FirstOrDefault();
        }

     }
}
