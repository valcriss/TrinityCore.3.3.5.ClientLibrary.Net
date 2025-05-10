using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("GemProperties.dbc")]
public class GemProperties : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int EnchantId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int MaxcountInv { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int MaxcountItem { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int Type { get; set; }

    public SpellItemEnchantment? GetEnchantIdSpellItemEnchantment()
    {
        return DbcDirectory.Open<SpellItemEnchantment>()?.Where(c => c.Id == EnchantId).FirstOrDefault();
    }
}