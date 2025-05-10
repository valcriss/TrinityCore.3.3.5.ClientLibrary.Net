using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("CinematicSequences.dbc")]
    public class CinematicSequences : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int SoundId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 8)]
        public int[]? Camera { get; set; }

        public SoundEntries? GetSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundId).FirstOrDefault();
        }

        public CinematicCamera[]? GetCameraCinematicCameras()
        {
               return DbcDirectory.Open<CinematicCamera>()?.Where(c => this.Camera != null && this.Camera.Contains(c.Id)).ToArray();
        }

     }
}
