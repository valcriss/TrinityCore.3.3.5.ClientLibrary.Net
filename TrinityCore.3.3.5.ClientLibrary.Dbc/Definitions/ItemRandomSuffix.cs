using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("ItemRandomSuffix.dbc")]
public class ItemRandomSuffix : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(2, DbcColumnDataType.StringRef)]
    public string? InternalName { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfUint32, 5)]
    public int[]? Enchantment { get; set; }

    [DbcColumn(4, DbcColumnDataType.ArrayOfUint32, 5)]
    public int[]? AllocationPct { get; set; }

    public SpellItemEnchantment[]? GetEnchantmentSpellItemEnchantments()
    {
        return DbcDirectory.Open<SpellItemEnchantment>()?.Where(c => Enchantment != null && Enchantment.Contains(c.Id)).ToArray();
    }
}