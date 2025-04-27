namespace TrinityCore._3._3._5.ClientLibrary.Shared.Security;

using CryptoNS = System.Security.Cryptography;

public static class HashHelper
{
    #region Private Fields

    private static readonly Dictionary<HashAlgorithm, HashFunction> _hashFunctions = new() { [HashAlgorithm.SHA1] = Sha1 };

    #endregion Private Fields

    #region Internal Methods

    public static byte[] Hash(this HashAlgorithm algorithm, params byte[][] data)
    {
        return _hashFunctions[algorithm](data);
    }

    #endregion Internal Methods

    #region Private Delegates

    private delegate byte[] HashFunction(params byte[][] data);

    #endregion Private Delegates

    #region Private Methods

    private static byte[] Combine(byte[][] buffers)
    {
        int length = 0;
        foreach (byte[] buffer in buffers)
            length += buffer.Length;

        byte[] result = new byte[length];

        int position = 0;

        foreach (byte[] buffer in buffers)
        {
            Buffer.BlockCopy(buffer, 0, result, position, buffer.Length);
            position += buffer.Length;
        }

        return result;
    }

    private static byte[] Sha1(params byte[][] data)
    {
        using CryptoNS.SHA1 alg = CryptoNS.SHA1.Create();
        return alg.ComputeHash(Combine(data));
    }

    #endregion Private Methods
}

public enum HashAlgorithm
{
    SHA1
}