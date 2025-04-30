using TrinityCore._3._3._5.ClientLibrary.Network.Core.Readers;
using TrinityCore._3._3._5.ClientLibrary.Shared.Enums;
using TrinityCore._3._3._5.ClientLibrary.Shared.Logger;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;
using TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Security;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Network;

public class WorldFrameHeaderReader : FrameHeaderReader<WorldCommands>
{
    private readonly AuthenticationCrypto _crypto;

    public WorldFrameHeaderReader(AuthenticationCrypto crypto)
    {
        _crypto = crypto;
    }

    public override bool ReadHeader(List<byte>? data)
    {
        if (data == null || data.Count < 4)
            return false;
        byte[] dataBuffer = data.ToArray();
        _crypto.Decrypt(dataBuffer, 0, 1);
        if ((dataBuffer[0] & 0x80) != 0)
        {
            byte temp = dataBuffer[0];
            HeaderLength = 5;
            dataBuffer[0] = (byte)(0x7f & temp);
        }
        else
        {
            HeaderLength = 4;
        }

        if (dataBuffer.Length < HeaderLength)
            return false;

        _crypto.Decrypt(dataBuffer, 1, HeaderLength - 1);
        switch (HeaderLength)
        {
            case 4:
                ExpectedPayloadLength = (int)(((uint)dataBuffer[0] << 8) | dataBuffer[1]) - 2;
                Command = (WorldCommands)BitConverter.ToUInt16(dataBuffer, 2);
                break;
            case 5:
                ExpectedPayloadLength = (int)((((uint)dataBuffer[0] & 0x7F) << 16) | ((uint)dataBuffer[1] << 8) | dataBuffer[2]) - 2;
                Command = (WorldCommands)BitConverter.ToUInt16(dataBuffer, 3);
                break;
            default:
                Log.Error($"WorldFrameHeaderReader: Invalid header length: {HeaderLength}");
                IsValid = false;
                break;
        }

        IsValid = Enum.IsDefined(typeof(WorldCommands), Command);
        if (!IsValid) Log.Error($"WorldFrameHeaderReader: Invalid command: {HeaderLength} {Command}");
        return true;
    }

    private byte[]? DecryptHeaderData(byte[]? data)
    {
        if (data == null || data.Length < 4)
        {
            Log.Error($"WorldFrameHeaderReader: Invalid data length: {data?.Length}");
            return data;
        }

        if (!_crypto.IsInitialized) return data;
        byte[] headerData = new byte[6]; // Taille maximale possible de l'en-tête (pour les paquets larges)
        Array.Copy(data, headerData, Math.Min(6, data.Length));
        _crypto.Decrypt(headerData, 0, headerData.Length);
        return headerData;
    }
}