namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;

public class Realm
{
    public string Address { get; set; } = string.Empty;
    public ushort Build { get; set; }
    public byte Flags { get; set; }
    public uint Id { get; set; }
    public byte Load { get; set; }
    public byte Locked { get; set; }
    public string Name { get; set; } = string.Empty;
    public float Population { get; set; }
    public int Port { get; set; }
    public byte Timezone { get; set; }
    public byte Type { get; set; }
    public byte VersionBugFix { get; set; }
    public byte VersionMajor { get; set; }
    public byte VersionMinor { get; set; }
    
    public override string ToString()
    {
        return Name;
    }
}