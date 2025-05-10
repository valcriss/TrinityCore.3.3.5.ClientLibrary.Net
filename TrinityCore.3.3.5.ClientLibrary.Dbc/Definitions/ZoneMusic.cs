using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ZoneMusic.dbc")]
    public class ZoneMusic : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? SetName { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 2)]
        public int[]? SilenceIntervalMin { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfUint32, 2)]
        public int[]? SilenceIntervalMax { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfUint32, 2)]
        public int[]? Sounds { get; set; }

        public SoundEntries[]? GetSoundsSoundEntriess()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => this.Sounds != null && this.Sounds.Contains(c.Id)).ToArray();
        }

     }
}
