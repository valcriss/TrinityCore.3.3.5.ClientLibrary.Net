using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SpellItemEnchantment.dbc")]
    public class SpellItemEnchantment : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Charges { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 3)]
        public int[]? Effect { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfUint32, 3)]
        public int[]? EffectPointsMin { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfUint32, 3)]
        public int[]? EffectPointsMax { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.ArrayOfUint32, 3)]
        public int[]? EffectArg { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int ItemVisual { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int SrcItemId { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Int32)]
        public int ConditionId { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int RequiredSkillId { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int RequiredSkillRank { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int MinLevel { get; set; }

        public Spell[]? GetEffectArgSpells()
        {
               return DbcDirectory.Open<Spell>()?.Where(c => this.EffectArg != null && this.EffectArg.Contains(c.Id)).ToArray();
        }

        public ItemVisuals? GetItemVisualItemVisuals()
        {
               return DbcDirectory.Open<ItemVisuals>()?.Where(c => c.Id == this.ItemVisual).FirstOrDefault();
        }

        public SpellItemEnchantmentCondition? GetConditionIdSpellItemEnchantmentCondition()
        {
               return DbcDirectory.Open<SpellItemEnchantmentCondition>()?.Where(c => c.Id == this.ConditionId).FirstOrDefault();
        }

        public SkillLine? GetRequiredSkillIdSkillLine()
        {
               return DbcDirectory.Open<SkillLine>()?.Where(c => c.Id == this.RequiredSkillId).FirstOrDefault();
        }

     }
}
