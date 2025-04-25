namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Security;

public class Arc4
{
    private readonly byte[] _state;
    private byte _x, _y;

    internal Arc4(byte[] key)
    {
        _state = new byte[256];
        _x = _y = 0;
        KeySetup(key);
    }

    internal int Process(byte[] buffer, int start, int count)
    {
        return InternalTransformBlock(buffer, start, count, buffer, start);
    }

    private int InternalTransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer,
        int outputOffset)
    {
        for (int counter = 0; counter < inputCount; counter++)
        {
            _x = (byte)(_x + 1);
            _y = (byte)(_state[_x] + _y);
            // swap byte
            (_state[_y], _state[_x]) = (_state[_x], _state[_y]);

            byte xorIndex = (byte)(_state[_x] + _state[_y]);
            outputBuffer[outputOffset + counter] = (byte)(inputBuffer[inputOffset + counter] ^ _state[xorIndex]);
        }

        return inputCount;
    }

    private void KeySetup(byte[] key)
    {
        byte index1 = 0;
        byte index2 = 0;

        for (int counter = 0; counter < 256; counter++) _state[counter] = (byte)counter;
        _x = 0;
        _y = 0;
        for (int counter = 0; counter < 256; counter++)
        {
            index2 = (byte)(key[index1] + _state[counter] + index2);
            // swap byte
            (_state[index2], _state[counter]) = (_state[counter], _state[index2]);

            index1 = (byte)((index1 + 1) % key.Length);
        }
    }
}