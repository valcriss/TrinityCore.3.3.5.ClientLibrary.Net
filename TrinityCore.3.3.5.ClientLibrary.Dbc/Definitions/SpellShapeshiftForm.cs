using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("SpellShapeshiftForm.dbc")]
    public class SpellShapeshiftForm : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int BonusActionBar { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int CreatureType { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int AttackIconId { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int CombatRoundTime { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.ArrayOfUint32, 4)]
        public int[]? CreatureDisplayId { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.ArrayOfUint32, 8)]
        public int[]? PresetSpellId { get; set; }

        public CreatureType? GetCreatureTypeCreatureType()
        {
               return DbcDirectory.Open<CreatureType>()?.Where(c => c.Id == this.CreatureType).FirstOrDefault();
        }

        public SpellIcon? GetAttackIconIdSpellIcon()
        {
               return DbcDirectory.Open<SpellIcon>()?.Where(c => c.Id == this.AttackIconId).FirstOrDefault();
        }

        public CreatureDisplayInfo[]? GetCreatureDisplayIdCreatureDisplayInfos()
        {
               return DbcDirectory.Open<CreatureDisplayInfo>()?.Where(c => this.CreatureDisplayId != null && this.CreatureDisplayId.Contains(c.Id)).ToArray();
        }

        public Spell[]? GetPresetSpellIdSpells()
        {
               return DbcDirectory.Open<Spell>()?.Where(c => this.PresetSpellId != null && this.PresetSpellId.Contains(c.Id)).ToArray();
        }

     }
}
