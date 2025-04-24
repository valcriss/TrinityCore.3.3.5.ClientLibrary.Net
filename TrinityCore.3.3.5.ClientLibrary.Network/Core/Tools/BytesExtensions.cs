using System.Numerics;
using System.Text;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Tools;

public static class BytesExtensions
{

        public static byte[] Append(this byte[] array1, byte value)
        {
            return array1.Append(new[] { value });
        }

        public static byte[] Append(this byte[] array1, byte[] array2, int length = -1)
        {
            array1 ??= Array.Empty<byte>();
            if (array2 == null) return array1;
            if (length == -1) length = array2.Length;

            byte[] buffer = new byte[array1.Length + length];

            Array.ConstrainedCopy(array1, 0, buffer, 0, array1.Length);
            Array.ConstrainedCopy(array2, 0, buffer, array1.Length, length);

            return buffer;
        }

        public static string BytesToString(this byte[] value)
        {
            return BitConverter.ToString(value).Replace("-", "");
        }

        public static byte[] Decompress(this byte[] data)
        {
            try
            {
                int length = (int)BitConverter.ToUInt32(data, 0);
                byte[] output = new byte[length];
                byte[] buffer = data.Split(4, data.Length - 4);

                Stream s = new InflaterInputStream(new MemoryStream(buffer));
                int offset = 0;
                while (true)
                {
                    int size = s.Read(output, offset, length);
                    if (size == length) break;
                    offset += size;
                    length -= size;
                }

                return output;
            }
            catch
            {
                return Array.Empty<byte>();
            }
        }

        public static BigInteger ModPow(this BigInteger value, BigInteger pow, BigInteger mod)
        {
            return BigInteger.ModPow(value, pow, mod);
        }

        public static string ReadCString(this byte[] data, int start, out int length)
        {
            StringBuilder builder = new();
            length = 0;
            while (true)
            {
                byte letter = data[start];
                start++;
                length++;
                if (letter == 0)
                    break;

                builder.Append((char)letter);
            }

            return builder.ToString();
        }

        public static byte[] Split(this byte[] data, int startIndex, int length)
        {
            byte[] buffer = new byte[length];
            Array.ConstrainedCopy(data, startIndex, buffer, 0, length);
            return buffer;
        }

        public static byte[] SubArray(this byte[] array, int start, int count)
        {
            byte[] subArray = new byte[count];
            Array.Copy(array, start, subArray, 0, count);
            return subArray;
        }

        public static BigInteger ToBigInteger(this byte[] array)
        {
            byte[] temp;
            if ((array[^1] & 0x80) == 0x80)
            {
                temp = new byte[array.Length + 1];
                temp[array.Length] = 0;
            }
            else
            {
                temp = new byte[array.Length];
            }

            Array.Copy(array, temp, array.Length);
            return new BigInteger(temp);
        }

        public static byte[] ToCleanByteArray(this BigInteger b)
        {
            byte[] array = b.ToByteArray();
            if (array[^1] != 0)
                return array;

            byte[] temp = new byte[array.Length - 1];
            Array.Copy(array, temp, temp.Length);
            return temp;
        }

        public static byte[] ToCString(this string str)
        {
            byte[] utf8StringBytes = Encoding.UTF8.GetBytes(str);
            byte[] data = new byte[utf8StringBytes.Length + 1];
            Array.Copy(utf8StringBytes, data, utf8StringBytes.Length);
            data[^1] = 0;
            return data;
        }

        public static string ToHexString(this byte[] array)
        {
            StringBuilder builder = new();

            for (int i = array.Length - 1; i >= 0; --i)
                builder.Append(array[i].ToString("X2"));

            return builder.ToString();
        }
        
}