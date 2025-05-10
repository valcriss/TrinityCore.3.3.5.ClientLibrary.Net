using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SoundEntriesAdvanced.dbc")]
    public class SoundEntriesAdvanced : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int SoundEntryId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Float)]
        public float InnerRadius2D { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int TimeA { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int TimeB { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int TimeC { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int TimeD { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int RandomOffsetRange { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int Usage { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int TimeIntervalMin { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int TimeIntervalMax { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int VolumeSliderCategory { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Float)]
        public float DuckToSFX { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Float)]
        public float DuckToMusic { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Float)]
        public float DuckToAmbience { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.Float)]
        public float InnerRadiusOfInfluence { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.Float)]
        public float OuterRadiusOfInfluence { get; set; }

        [DbcColumn(17, Enums.DbcColumnDataType.Int32)]
        public int TimeToDuck { get; set; }

        [DbcColumn(18, Enums.DbcColumnDataType.Int32)]
        public int TimeToUnduck { get; set; }

        [DbcColumn(19, Enums.DbcColumnDataType.Float)]
        public float InsideAngle { get; set; }

        [DbcColumn(20, Enums.DbcColumnDataType.Float)]
        public float OutsideAngle { get; set; }

        [DbcColumn(21, Enums.DbcColumnDataType.Float)]
        public float OutsideVolume { get; set; }

        [DbcColumn(22, Enums.DbcColumnDataType.Float)]
        public float OuterRadius2D { get; set; }

        [DbcColumn(23, Enums.DbcColumnDataType.StringRef)]
        public string? Name { get; set; }

        public SoundEntries? GetSoundEntryIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundEntryId).FirstOrDefault();
        }

     }
}
