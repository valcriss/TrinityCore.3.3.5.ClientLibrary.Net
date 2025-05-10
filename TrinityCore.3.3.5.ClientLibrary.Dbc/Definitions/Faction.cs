using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("Faction.dbc")]
    public class Faction : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int ReputationIndex { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfUint32, 4)]
        public int[]? ReputationRaceMask { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfUint32, 4)]
        public int[]? ReputationClassMask { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.ArrayOfUint32, 4)]
        public int[]? ReputationBase { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.ArrayOfUint32, 4)]
        public int[]? ReputationFlags { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int ParentFactionId { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.ArrayOfFloat, 2)]
        public float[]? ParentFactionMod { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.ArrayOfUint32, 2)]
        public int[]? ParentFactionCap { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Loc)]
        public string? Description { get; set; }

        public Faction? GetParentFactionIdFaction()
        {
               return DbcDirectory.Open<Faction>()?.Where(c => c.Id == this.ParentFactionId).FirstOrDefault();
        }

     }
}
