using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SpellVisualKitModelAttach.dbc")]
    public class SpellVisualKitModelAttach : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int ParentSpellVisualKitId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int SpellVisualEffectNameId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int AttachmentId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? Offset { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Float)]
        public float Yaw { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Float)]
        public float Pitch { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Float)]
        public float Roll { get; set; }

        public SpellVisualKit? GetParentSpellVisualKitIdSpellVisualKit()
        {
               return DbcDirectory.Open<SpellVisualKit>()?.Where(c => c.Id == this.ParentSpellVisualKitId).FirstOrDefault();
        }

        public SpellVisualEffectName? GetSpellVisualEffectNameIdSpellVisualEffectName()
        {
               return DbcDirectory.Open<SpellVisualEffectName>()?.Where(c => c.Id == this.SpellVisualEffectNameId).FirstOrDefault();
        }

     }
}
