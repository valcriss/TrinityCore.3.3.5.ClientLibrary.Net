using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("ItemRandomProperties.dbc")]
    public class ItemRandomProperties : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.StringRef)]
        public string? Name { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 5)]
        public int[]? Enchantment { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        public SpellItemEnchantment[]? GetEnchantmentSpellItemEnchantments()
        {
               return DbcDirectory.Open<SpellItemEnchantment>()?.Where(c => this.Enchantment != null && this.Enchantment.Contains(c.Id)).ToArray();
        }

     }
}
