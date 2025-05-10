using System.Reflection;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Extensions
{
    internal static class DbcFileExtensions
    {
        internal static int GetDbcFileColumnCount(this Type type)
        {
            int count = 0;

            PropertyInfo[] properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = properties[i];
                DbcColumnAttribute? attribute = property.GetCustomAttribute<DbcColumnAttribute>();
                if (attribute != null)
                {
                    if (attribute.DataType == DbcColumnDataType.Loc)
                    {
                        count += Enum.GetNames(typeof(DbcLocale)).Length;
                    }
                    else if (attribute.DataType == DbcColumnDataType.ArrayOfBool || attribute.DataType == DbcColumnDataType.ArrayOfFloat || attribute.DataType == DbcColumnDataType.ArrayOfUint32 || attribute.DataType == DbcColumnDataType.ArrayOfStringRef)
                    {
                        count += attribute.ArrayCount;
                    }
                    else
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        internal static string? GetDbcFilename(this Type type)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(type);
            Attribute? attribute = attributes.FirstOrDefault(c => c is DbcFileAttribute);
            if (attribute != null)
            {
                DbcFileAttribute dbcFileAttribute = (DbcFileAttribute)attribute;
                return dbcFileAttribute.Filename;
            }
            return null;
        }

        internal static DbcFileProperty[] GetDbcFileProperties(this Type type)
        {
            List<DbcFileProperty> result = new List<DbcFileProperty>();
            PropertyInfo[] properties = type.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = properties[i];
                DbcColumnAttribute? attribute = property.GetCustomAttribute<DbcColumnAttribute>();
                if (attribute != null)
                {
                    result.Add(new DbcFileProperty(property, attribute.Column, attribute.DataType, attribute.ArrayCount));
                }
            }

            return result.OrderBy(c => c.Column).ToArray();
        }

        internal static T ReadItem<T>(this byte[] content, Dictionary<uint, string> stringBlocks) where T : DbcFile, new()
        {
            DbcFileProperty[] properties = typeof(T).GetDbcFileProperties();
            T item = new T();
            int index = 0;
            foreach (DbcFileProperty property in properties)
            {
                property.Property.SetValue(item, property.ReadValue(ref index, content, stringBlocks));
            }
            return item;
        }
    }
}