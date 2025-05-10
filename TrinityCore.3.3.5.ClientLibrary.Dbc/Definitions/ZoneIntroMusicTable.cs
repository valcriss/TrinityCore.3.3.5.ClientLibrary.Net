using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ZoneIntroMusicTable.dbc")]
    public class ZoneIntroMusicTable : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? Name { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int SoundId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int Priority { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int MinDelayMinutes { get; set; }

        public SoundEntries? GetSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundId).FirstOrDefault();
        }

     }
}
