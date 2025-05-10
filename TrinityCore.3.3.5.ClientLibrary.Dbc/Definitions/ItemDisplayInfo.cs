using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ItemDisplayInfo.dbc")]
    public class ItemDisplayInfo : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.ArrayOfStringRef, 2)]
        public string[]? ModelName { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfStringRef, 2)]
        public string[]? ModelTexture { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfStringRef, 2)]
        public string[]? InventoryIcon { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfUint32, 3)]
        public int[]? GeosetGroup { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int SpellVisualId { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int GroupSoundIndex { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.ArrayOfUint32, 2)]
        public int[]? HelmetGeosetVisId { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.ArrayOfStringRef, 8)]
        public string[]? Texture { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int ItemVisual { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int ParticleColorId { get; set; }

        public SpellVisual? GetSpellVisualIdSpellVisual()
        {
               return DbcDirectory.Open<SpellVisual>()?.Where(c => c.Id == this.SpellVisualId).FirstOrDefault();
        }

        public ParticleColor? GetParticleColorIdParticleColor()
        {
               return DbcDirectory.Open<ParticleColor>()?.Where(c => c.Id == this.ParticleColorId).FirstOrDefault();
        }

     }
}
