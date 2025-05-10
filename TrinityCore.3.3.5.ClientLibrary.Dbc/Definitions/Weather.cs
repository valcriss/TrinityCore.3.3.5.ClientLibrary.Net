using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("Weather.dbc")]
    public class Weather : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int AmbienceId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int EffectType { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Float)]
        public float TransitionSkyBox { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? EffectColor { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.StringRef)]
        public string? EffectTexture { get; set; }

        public SoundEntries? GetAmbienceIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.AmbienceId).FirstOrDefault();
        }

     }
}
