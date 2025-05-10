using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SoundEmitters.dbc")]
    public class SoundEmitters : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? Position { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? Direction { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int SoundEntryAdvancedId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int MapId { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.StringRef)]
        public string? Name { get; set; }

        public SoundEntriesAdvanced? GetSoundEntryAdvancedIdSoundEntriesAdvanced()
        {
               return DbcDirectory.Open<SoundEntriesAdvanced>()?.Where(c => c.Id == this.SoundEntryAdvancedId).FirstOrDefault();
        }

        public Map? GetMapIdMap()
        {
               return DbcDirectory.Open<Map>()?.Where(c => c.Id == this.MapId).FirstOrDefault();
        }

     }
}
