using System.Reflection;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc;

internal class DbcFileProperty
{
    public DbcFileProperty(PropertyInfo property, int column, DbcColumnDataType dataType, int arrayCount)
    {
        Property = property;
        Column = column;
        DataType = dataType;
        ArrayCount = arrayCount;
    }

    internal int ArrayCount { get; set; }
    internal int Column { get; set; }
    internal DbcColumnDataType DataType { get; set; }
    internal PropertyInfo Property { get; set; }

    internal object? ReadValue(ref int index, byte[] content, Dictionary<uint, string> stringBlocks)
    {
        switch (DataType)
        {
            case DbcColumnDataType.Bool:
                return ReadBool(ref index, content);

            case DbcColumnDataType.Byte:
                return ReadByte(ref index, content);

            case DbcColumnDataType.UInt8:
                return ReadUInt8(ref index, content);

            case DbcColumnDataType.UInt32:
                return ReadUint(ref index, content);

            case DbcColumnDataType.Int32:
                return ReadInt(ref index, content);

            case DbcColumnDataType.ArrayOfFloat:
                return ReadFloatArray(ref index, content);

            case DbcColumnDataType.ArrayOfBool:
                return ReadBoolArray(ref index, content);

            case DbcColumnDataType.ArrayOfUint32:
                return ReadUintArray(ref index, content);

            case DbcColumnDataType.ArrayOfStringRef:
                return ReadArrayOfStringRef(ref index, content, stringBlocks);

            case DbcColumnDataType.Float:
                return ReadFloat(ref index, content);

            case DbcColumnDataType.StringRef:
                uint stringIndex = ReadUint(ref index, content);
                if (!stringBlocks.ContainsKey(stringIndex)) return null;
                return stringBlocks[stringIndex];

            case DbcColumnDataType.Loc:
                uint stringLocIndex = ReadLoc(ref index, content);
                if (!stringBlocks.ContainsKey(stringLocIndex)) return null;
                return stringBlocks[stringLocIndex];

            default:
                return null;
        }
    }

    private static bool ReadBool(ref int index, byte[] content)
    {
        byte result = content[index];
        index += 1;
        return result == 0x01;
    }

    private static byte ReadByte(ref int index, byte[] content)
    {
        byte value = content[index];
        index += 1;
        return value;
    }

    private static float ReadFloat(ref int index, byte[] content)
    {
        float value = BitConverter.ToSingle(content, index);
        index += 4;
        return value;
    }

    private static int ReadInt(ref int index, byte[] content)
    {
        int value = BitConverter.ToInt32(content, index);
        index += 4;
        return value;
    }

    private static uint ReadLoc(ref int index, byte[] content)
    {
        Dictionary<DbcLocale, uint> locales = new();
        foreach (DbcLocale locale in (DbcLocale[])Enum.GetValues(typeof(DbcLocale)))
        {
            uint value = BitConverter.ToUInt32(content, index);
            index += 4;
            locales.Add(locale, value);
        }

        return locales[DbcDirectory.GetLocale()];
    }

    private static uint ReadUint(ref int index, byte[] content)
    {
        uint value = BitConverter.ToUInt32(content, index);
        index += 4;
        return value;
    }

    private static sbyte ReadUInt8(ref int index, byte[] content)
    {
        sbyte value = (sbyte)content[index];
        index += 1;
        return value;
    }

    private string?[] ReadArrayOfStringRef(ref int index, byte[] content, Dictionary<uint, string> stringBlocks)
    {
        string?[]? result = new string[ArrayCount];
        for (int i = 0; i < ArrayCount; i++)
        {
            uint value = BitConverter.ToUInt32(content, index);
            index += 4;
            result[i] = stringBlocks.ContainsKey(value) ? stringBlocks[value] : null;
        }

        return result;
    }

    private bool[] ReadBoolArray(ref int index, byte[] content)
    {
        bool[] result = new bool[ArrayCount];
        for (int i = 0; i < ArrayCount; i++)
        {
            bool value = ReadBool(ref index, content);
            result[i] = value;
        }

        return result;
    }

    private float[] ReadFloatArray(ref int index, byte[] content)
    {
        float[] result = new float[ArrayCount];
        for (int i = 0; i < ArrayCount; i++)
        {
            float value = ReadFloat(ref index, content);
            result[i] = value;
        }

        return result;
    }

    private uint[] ReadUintArray(ref int index, byte[] content)
    {
        uint[] result = new uint[ArrayCount];
        for (int i = 0; i < ArrayCount; i++)
        {
            uint value = BitConverter.ToUInt32(content, index);
            index += 4;
            result[i] = value;
        }

        return result;
    }
}