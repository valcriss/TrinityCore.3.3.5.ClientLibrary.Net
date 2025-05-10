using System.Reflection;
using System.Text;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Extensions;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc;

public class DbcFile
{
    public static List<T> Read<T>(DbcHeader header, byte[] content) where T : DbcFile, new()
    {
        List<T> records = new();
        Dictionary<uint, string> stringBlocks = ReadStringBlocks(header, content);

        for (int itemIndex = 0; itemIndex < header.RecordCount; itemIndex++)
        {
            byte[] itemContent = new byte[header.RecordSize];
            Array.Copy(content, DbcHeader.DBC_HEADER_LENGTH + itemIndex * header.RecordSize, itemContent, 0, header.RecordSize);
            T item = itemContent.ReadItem<T>(stringBlocks);
            records.Add(item);
        }

        return records;
    }

    public override string ToString()
    {
        StringBuilder builder = new();
        foreach (PropertyInfo property in GetType().GetProperties()) builder.Append(property.Name + "=" + property.GetValue(this) + ", ");
        builder.Remove(builder.Length - 2, 2);
        return builder.ToString();
    }

    private static Dictionary<uint, string> ReadStringBlocks(DbcHeader header, byte[] content)
    {
        Dictionary<uint, string> values = new();
        int offset = DbcHeader.DBC_HEADER_LENGTH + (int)header.RecordCount * (int)header.RecordSize;
        byte[] buffer = new byte[header.StringBlockSize];
        Array.Copy(content, offset, buffer, 0, header.StringBlockSize);

        List<byte> currentString = new();
        uint currentRead = 0;
        for (uint i = 0; i < buffer.Length; i++)
        {
            currentRead++;
            byte b = buffer[i];
            if (b != 0)
            {
                currentString.Add(b);
            }
            else
            {
                string current = Encoding.UTF8.GetString(currentString.ToArray());
                uint id = i + 1 - currentRead;
                values.Add(id, current);
                currentString.Clear();
                currentRead = 0;
            }
        }

        return values;
    }
}