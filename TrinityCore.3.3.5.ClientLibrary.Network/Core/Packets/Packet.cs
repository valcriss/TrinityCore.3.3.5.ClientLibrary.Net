using System.Numerics;
using System.Text;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Tools;
using TrinityCore._3._3._5.ClientLibrary.Shared.Math;

namespace TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;

public class Packet
{
    public Packet(byte[]? content = null, int readIndex = 0)
    {
        ReadIndex = readIndex;
        Data = content ?? [];
    }

    protected int ReadIndex { get; private set; }
    protected byte[]? Data { get; set; }

    public byte[]? GetData()
    {
        return Data;
    }

    public void Append(byte value)
    {
        Data = Data?.Append(value);
    }

    public void Append(ushort value)
    {
        Data = Data?.Append(BitConverter.GetBytes(value));
    }

    public void Append(float value)
    {
        Data = Data?.Append(BitConverter.GetBytes(value));
    }

    public void Append(uint value)
    {
        Data = Data?.Append(BitConverter.GetBytes(value));
    }

    public void Append(string message)
    {
        byte[] value = Encoding.UTF8.GetBytes(message);
        byte[] content = new byte[value.Length + 1];
        Array.ConstrainedCopy(value, 0, content, 0, value.Length);
        Append(content);
    }

    public void Append(ulong value)
    {
        Data = Data?.Append(BitConverter.GetBytes(value));
    }

    public void Append(byte[] value)
    {
        Data = Data?.Append(value);
    }

    public DateTime ReadPackedTime()
    {
        int packedDate = ReadInt32();
        int minute = packedDate & 0x3F;
        int hour = (packedDate >> 6) & 0x1F;
        int day = (packedDate >> 14) & 0x3F;
        int month = (packedDate >> 20) & 0xF;
        int year = (packedDate >> 24) & 0x1F;

        return new DateTime(2000, 1, 1).AddYears(year).AddMonths(month).AddDays(day).AddHours(hour)
            .AddMinutes(minute);
    }

    public bool IsDataLeft()
    {
        return Data?.Length > ReadIndex;
    }

    public int DataLeftLength()
    {
        return Data?.Length - ReadIndex ?? 0;
    }

    public byte PeekByte()
    {
        if (Data == null)
            return 0;
        return Data[ReadIndex];
    }

    public bool ReadBoolean()
    {
        byte b = ReadByte();
        return b > 0;
    }

    public byte ReadByte()
    {
        if (Data == null)
            return 0;
        byte value = Data[ReadIndex];
        ReadIndex++;
        return value;
    }

    public byte[] ReadBytes(int length)
    {
        if (Data == null || Data.Length < ReadIndex + length)
            return [];
        byte[] buffer = new byte[length];
        Array.ConstrainedCopy(Data, ReadIndex, buffer, 0, length);
        ReadIndex += length;
        return buffer;
    }

    public string ReadCString()
    {
        if (Data == null)
            return string.Empty;
        string value = Data.ReadCString(ReadIndex, out int length);
        ReadIndex += length;
        return value;
    }

    public int ReadInt32()
    {
        if (Data == null || Data.Length < ReadIndex + 4)
            return 0;
        int value = BitConverter.ToInt32(Data, ReadIndex);
        ReadIndex += 4;
        return value;
    }

    public string ReadInt32String()
    {
        int length = ReadInt32();
        byte[] raw = ReadBytes(length);
        StringBuilder builder = new();
        for (int i = 0; i < raw.Length; i++)
            if (raw[i] != 0)
                builder.Append((char)raw[i]);

        return builder.ToString();
    }

    public long ReadInt64()
    {
        if (Data == null || Data.Length <= ReadIndex + 8)
            return 0;
        long value = BitConverter.ToInt64(Data, ReadIndex);
        ReadIndex += 8;
        return value;
    }

    public DateTime ReadPackedDate()
    {
        uint packed = ReadUInt32();

        int min = (int)(packed & 0x3F);
        int hour = (int)((packed >> 6) & 0x1F);
        int day = (int)(((packed >> 14) & 0x3F) + 1);
        int mon = (int)(((packed >> 20) & 0xF) + 1);
        int year = (int)(((packed >> 24) & 0x1F) + 2000);

        return new DateTime(year, mon, day, hour, min, 0);
    }

    public ulong ReadPackedGuid()
    {
        byte mask = ReadByte();

        if (mask == 0)
            return 0;

        ulong res = 0;

        int i = 0;
        while (i < 8)
        {
            if ((mask & (1 << i)) != 0)
                res += (ulong)ReadByte() << (i * 8);

            i++;
        }

        return res;
    }

    public sbyte ReadSByte()
    {
        if (Data == null || Data.Length <= ReadIndex)
            return 0;
        sbyte value = (sbyte)Data[ReadIndex];
        ReadIndex++;
        return value;
    }

    public float ReadSingle()
    {
        if (Data == null || Data.Length < ReadIndex + 4)
            return 0;
        if (Data.Length - 4 > ReadIndex)
        {
            float value = BitConverter.ToSingle(Data, ReadIndex);
            ReadIndex += 4;
            return value;
        }

        ReadIndex = Data.Length - 1;
        return 0;
    }

    public ushort ReadUInt16()
    {
        if (Data == null || Data.Length < ReadIndex + 2)
            return 0;
        ushort value = BitConverter.ToUInt16(Data, ReadIndex);
        ReadIndex += 2;
        return value;
    }

    public uint ReadUInt32()
    {
        if (Data == null || Data.Length < ReadIndex + 4)
            return 0;
        uint value = BitConverter.ToUInt32(Data, ReadIndex);
        ReadIndex += 4;
        return value;
    }

    public string ReadUInt32String()
    {
        uint length = ReadUInt32();
        if (length == 0) return string.Empty;
        byte[] raw = ReadBytes((int)length);
        StringBuilder builder = new();
        for (int i = 0; i < raw.Length; i++)
            if (raw[i] != 0)
                builder.Append((char)raw[i]);

        return builder.ToString();
    }

    public ulong ReadUInt64()
    {
        if (Data == null || Data.Length < ReadIndex + 8)
            return 0;
        ulong value = BitConverter.ToUInt64(Data, ReadIndex);
        ReadIndex += 8;
        return value;
    }

    public Vector3 ReadVector3()
    {
        return new Vector3(ReadSingle(), ReadSingle(), ReadSingle());
    }

    public Coord ReadCoord()
    {
        return new Coord(ReadSingle(), ReadSingle(), ReadSingle());
    }
}