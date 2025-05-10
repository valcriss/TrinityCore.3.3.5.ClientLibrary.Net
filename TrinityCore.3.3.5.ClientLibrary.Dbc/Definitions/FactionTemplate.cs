using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("FactionTemplate.dbc")]
    public class FactionTemplate : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Faction { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int FactionGroup { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int FriendGroup { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int EnemyGroup { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.ArrayOfUint32, 4)]
        public int[]? Enemies { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.ArrayOfUint32, 4)]
        public int[]? Friend { get; set; }

        public Faction? GetFactionFaction()
        {
               return DbcDirectory.Open<Faction>()?.Where(c => c.Id == this.Faction).FirstOrDefault();
        }

        public FactionGroup? GetFactionGroupFactionGroup()
        {
               return DbcDirectory.Open<FactionGroup>()?.Where(c => c.Id == this.FactionGroup).FirstOrDefault();
        }

        public Faction[]? GetEnemiesFactions()
        {
               return DbcDirectory.Open<Faction>()?.Where(c => this.Enemies != null && this.Enemies.Contains(c.Id)).ToArray();
        }

        public Faction[]? GetFriendFactions()
        {
               return DbcDirectory.Open<Faction>()?.Where(c => this.Friend != null && this.Friend.Contains(c.Id)).ToArray();
        }

     }
}
