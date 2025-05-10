using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("CreatureDisplayInfoExtra.dbc")]
    public class CreatureDisplayInfoExtra : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int DisplayRaceId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int DisplaySexId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int SkinId { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int FaceId { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Int32)]
        public int HairStyleId { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Int32)]
        public int HairColorId { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int FacialHairId { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.ArrayOfUint32, 11)]
        public int[]? NPCItemDisplay { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.StringRef)]
        public string? BakeName { get; set; }

        public ChrRaces? GetDisplayRaceIdChrRaces()
        {
               return DbcDirectory.Open<ChrRaces>()?.Where(c => c.Id == this.DisplayRaceId).FirstOrDefault();
        }

        public ItemDisplayInfo[]? GetNPCItemDisplayItemDisplayInfos()
        {
               return DbcDirectory.Open<ItemDisplayInfo>()?.Where(c => this.NPCItemDisplay != null && this.NPCItemDisplay.Contains(c.Id)).ToArray();
        }

     }
}
