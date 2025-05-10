using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ObjectEffect.dbc")]
public class ObjectEffect : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.StringRef)]
    public string? Name { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int ObjectEffectGroupId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int TriggerType { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int EventType { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int EffectRecType { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int EffectRecId { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int Attachment { get; set; }

    [DbcColumn(8, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? Offset { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int ObjectEffectModifierId { get; set; }

    public ObjectEffectGroup? GetObjectEffectGroupIdObjectEffectGroup()
    {
        return DbcDirectory.Open<ObjectEffectGroup>()?.Where(c => c.Id == ObjectEffectGroupId).FirstOrDefault();
    }

    public ObjectEffectModifier? GetObjectEffectModifierIdObjectEffectModifier()
    {
        return DbcDirectory.Open<ObjectEffectModifier>()?.Where(c => c.Id == ObjectEffectModifierId).FirstOrDefault();
    }
}