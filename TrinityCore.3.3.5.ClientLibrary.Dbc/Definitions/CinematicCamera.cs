using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("CinematicCamera.dbc")]
    public class CinematicCamera : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? Model { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int SoundId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? Origin { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float OriginFacing { get; set; }

        public SoundEntries? GetSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundId).FirstOrDefault();
        }

     }
}
