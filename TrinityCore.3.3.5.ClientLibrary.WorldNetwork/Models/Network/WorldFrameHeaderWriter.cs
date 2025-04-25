using TrinityCore._3._3._5.ClientLibrary.Network.Core.Packets;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Tools;
using TrinityCore._3._3._5.ClientLibrary.Network.Core.Writers;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Security;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Network;

public class WorldFrameHeaderWriter: FrameHeaderWriter<WorldCommands>
{
    private readonly AuthenticationCrypto _crypto;

    public WorldFrameHeaderWriter(AuthenticationCrypto crypto)
    {
        _crypto = crypto;
    }
    
    public override byte[]? Create(OutgoingPacket<WorldCommands> packet)
    {
        byte[] buffer = packet.GetData();
        byte[] data = new byte[6];
        byte[] size = EncryptedSize(buffer.Length);
        byte[] command = EncryptedCommand(packet.Command);

        Array.Copy(size, 0, data, 0, 2);
        Array.Copy(command, 0, data, 2, 4);
        
        return data;
    }
    
    private byte[] EncryptedCommand(WorldCommands command)
    {
        byte[] encryptedCommand = BitConverter.GetBytes((uint)command);
        _crypto.Encrypt(encryptedCommand, 0, encryptedCommand.Length);
        return encryptedCommand;
    }

    private byte[] EncryptedSize(int bufferSize)
    {
        byte[] encryptedSize = BitConverter.GetBytes(bufferSize + 4).SubArray(0, 2);
        Array.Reverse(encryptedSize);
        _crypto.Encrypt(encryptedSize, 0, 2);
        return encryptedSize;
    }
}