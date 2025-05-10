using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("WeaponSwingSounds2.dbc")]
    public class WeaponSwingSounds2 : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int SwingType { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Crit { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int SoundId { get; set; }

        public SoundEntries? GetSoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.SoundId).FirstOrDefault();
        }

     }
}
