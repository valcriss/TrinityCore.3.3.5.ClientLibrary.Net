using System.Security.Cryptography;

namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Security;

public class AuthenticationCrypto
{
    private static readonly byte[] _decryptionKey =
    {
        0xCC, 0x98, 0xAE, 0x04, 0xE8, 0x97, 0xEA, 0xCA,
        0x12, 0xDD, 0xC0, 0x93, 0x42, 0x91, 0x53, 0x57
    };

    private static readonly byte[] _encryptionKey =
    {
        0xC2, 0xB3, 0x72, 0x3C, 0xC6, 0xAE, 0xD9, 0xB5,
        0x34, 0x3C, 0x53, 0xEE, 0x2F, 0x43, 0x67, 0xCE
    };

    private CryptoAuthStatus _status = CryptoAuthStatus.WAITING;
    private Arc4 _decryptionStream;
    private Arc4 _encryptionStream;

    public AuthenticationCrypto(byte[] sessionKey)
    {
        // create RC4-drop[1024] stream
        using (HMACSHA1 outputHmac = new(_encryptionKey))
        {
            _encryptionStream = new Arc4(outputHmac.ComputeHash(sessionKey));
        }

        _encryptionStream.Process(new byte[1024], 0, 1024);

        // create RC4-drop[1024] stream
        using (HMACSHA1 inputHmac = new(_decryptionKey))
        {
            _decryptionStream = new Arc4(inputHmac.ComputeHash(sessionKey));
        }

        _decryptionStream.Process(new byte[1024], 0, 1024);

        _status = CryptoAuthStatus.WAITING;
    }

    public void Activate()
    {
        _status = CryptoAuthStatus.READY;
    }
    
    public void Deactivate()
    {
        _status = CryptoAuthStatus.WAITING;
    }

    internal void Decrypt(byte[] data, int start, int count)
    {
        if (_status == CryptoAuthStatus.WAITING) return;
        _decryptionStream.Process(data, start, count);
    }

    internal void Encrypt(byte[] data, int start, int count)
    {
        if (_status == CryptoAuthStatus.WAITING) return;
        _encryptionStream.Process(data, start, count);
    }

    private enum CryptoAuthStatus
    {
        WAITING,
        READY
    }
}