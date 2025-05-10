using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("WorldSafeLocs.dbc")]
    public class WorldSafeLocs : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Continent { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? Loc { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Loc)]
        public string? AreaNameLang { get; set; }

        public Map? GetContinentMap()
        {
               return DbcDirectory.Open<Map>()?.Where(c => c.Id == this.Continent).FirstOrDefault();
        }

     }
}
