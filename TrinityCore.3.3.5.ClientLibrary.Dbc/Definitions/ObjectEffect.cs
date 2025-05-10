using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ObjectEffect.dbc")]
    public class ObjectEffect : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? Name { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int ObjectEffectGroupId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int TriggerType { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int EventType { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int EffectRecType { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int EffectRecId { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int Attachment { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? Offset { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int ObjectEffectModifierId { get; set; }

        public ObjectEffectGroup? GetObjectEffectGroupIdObjectEffectGroup()
        {
               return DbcDirectory.Open<ObjectEffectGroup>()?.Where(c => c.Id == this.ObjectEffectGroupId).FirstOrDefault();
        }

        public ObjectEffectModifier? GetObjectEffectModifierIdObjectEffectModifier()
        {
               return DbcDirectory.Open<ObjectEffectModifier>()?.Where(c => c.Id == this.ObjectEffectModifierId).FirstOrDefault();
        }

     }
}
