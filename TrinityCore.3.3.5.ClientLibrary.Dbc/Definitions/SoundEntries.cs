using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SoundEntries.dbc")]
    public class SoundEntries : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int SoundType { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.StringRef)]
        public string? Name { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfStringRef, 10)]
        public string[]? File { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfUint32, 10)]
        public int[]? Freq { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.StringRef)]
        public string? DirectoryBase { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Float)]
        public float VolumeFloat { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Float)]
        public float MinDistance { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Float)]
        public float DistanceCutoff { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int EAXDef { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int SoundEntriesAdvancedId { get; set; }

        public SoundEntriesAdvanced? GetSoundEntriesAdvancedIdSoundEntriesAdvanced()
        {
               return DbcDirectory.Open<SoundEntriesAdvanced>()?.Where(c => c.Id == this.SoundEntriesAdvancedId).FirstOrDefault();
        }

     }
}
