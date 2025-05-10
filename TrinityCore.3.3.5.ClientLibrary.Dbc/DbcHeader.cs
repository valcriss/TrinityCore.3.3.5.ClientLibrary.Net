namespace TrinityCore._3._3._5.ClientLibrary.Dbc
{
    public class DbcHeader
    {
        public const int DBC_HEADER_LENGTH = 20;
        public const int DBC_SIGNATURE = 1128416343;

        public uint fieldCount;
        public uint Magic;
        public uint RecordCount;
        public uint RecordSize;
        public uint StringBlockSize;

        public static DbcHeader? Read(byte[] content)
        {
            try
            {
                byte[] buffer = new byte[DBC_HEADER_LENGTH];
                Array.Copy(content, 0, buffer, 0, DBC_HEADER_LENGTH);
                DbcHeader header = new DbcHeader();
                header.Magic = BitConverter.ToUInt32(buffer, 0);
                header.RecordCount = BitConverter.ToUInt32(buffer, 4);
                header.fieldCount = BitConverter.ToUInt32(buffer, 8);
                header.RecordSize = BitConverter.ToUInt32(buffer, 12);
                header.StringBlockSize = BitConverter.ToUInt32(buffer, 16);
                return header;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}