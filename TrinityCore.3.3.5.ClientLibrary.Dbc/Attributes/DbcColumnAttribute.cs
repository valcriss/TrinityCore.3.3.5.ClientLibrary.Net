using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class DbcColumnAttribute : Attribute
{
    public DbcColumnAttribute(int column, DbcColumnDataType dataType, int arrayCount = 0)
    {
        Column = column;
        DataType = dataType;
        ArrayCount = arrayCount;
    }

    public int ArrayCount { get; set; }
    public int Column { get; set; }
    public DbcColumnDataType DataType { get; set; }
}