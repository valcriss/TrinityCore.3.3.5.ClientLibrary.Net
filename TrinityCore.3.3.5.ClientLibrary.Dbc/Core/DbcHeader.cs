namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Core;

public struct DbcHeader
{
    public uint Signature;
    public uint RecordCount;
    public uint FieldCount;
    public uint RecordSize;
    public uint StringBlockSize;
}