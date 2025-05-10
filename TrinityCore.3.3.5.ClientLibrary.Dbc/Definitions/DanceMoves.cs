using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("DanceMoves.dbc")]
    public class DanceMoves : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Type { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int Param { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Int32)]
        public int Fallback { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Int32)]
        public int Racemask { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.StringRef)]
        public string? InternalName { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Loc)]
        public string? NameLang { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Int32)]
        public int LockId { get; set; }

        public Lock? GetLockIdLock()
        {
               return DbcDirectory.Open<Lock>()?.Where(c => c.Id == this.LockId).FirstOrDefault();
        }

     }
}
