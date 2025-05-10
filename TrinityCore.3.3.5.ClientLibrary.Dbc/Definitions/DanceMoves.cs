using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("DanceMoves.dbc")]
public class DanceMoves : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Type { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int Param { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int Fallback { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int Racemask { get; set; }

    [DbcColumn(5, DbcColumnDataType.StringRef)]
    public string? InternalName { get; set; }

    [DbcColumn(6, DbcColumnDataType.Loc)]
    public string? NameLang { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int LockId { get; set; }

    public Lock? GetLockIdLock()
    {
        return DbcDirectory.Open<Lock>()?.Where(c => c.Id == LockId).FirstOrDefault();
    }
}