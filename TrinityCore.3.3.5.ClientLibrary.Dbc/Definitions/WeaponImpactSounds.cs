using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("WeaponImpactSounds.dbc")]
    public class WeaponImpactSounds : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int WeaponSubClassId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int ParrySoundType { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfUint32, 10)]
        public int[]? ImpactSoundId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfUint32, 10)]
        public int[]? CritImpactSoundId { get; set; }

        public SoundEntries[]? GetImpactSoundIdSoundEntriess()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => this.ImpactSoundId != null && this.ImpactSoundId.Contains(c.Id)).ToArray();
        }

        public SoundEntries[]? GetCritImpactSoundIdSoundEntriess()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => this.CritImpactSoundId != null && this.CritImpactSoundId.Contains(c.Id)).ToArray();
        }

     }
}
