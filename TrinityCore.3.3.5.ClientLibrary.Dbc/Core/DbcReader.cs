using System.Text;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Core;

public class DbcReader
{
    private const uint DBC_HEADER_SIGNATURE = 0x43424457; // WDBC en little-endian
    private readonly byte[] _data;

    private readonly DbcHeader _header;
    private readonly byte[] _stringBlock;

    public DbcReader(string filePath, LocaleConstant locale = LocaleConstant.LOCALE_EN_US)
    {
        using (FileStream fileStream = new(filePath, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new(fileStream))
        {
            // Lire l'en-tête DBC
            _header = new DbcHeader
            {
                Signature = reader.ReadUInt32(),
                RecordCount = reader.ReadUInt32(),
                FieldCount = reader.ReadUInt32(),
                RecordSize = reader.ReadUInt32(),
                StringBlockSize = reader.ReadUInt32()
            };

            // Vérifier la signature
            if (_header.Signature != DBC_HEADER_SIGNATURE) throw new InvalidDataException("Ce fichier n'est pas un fichier DBC valide.");

            // Lire les enregistrements de données
            _data = reader.ReadBytes((int)(_header.RecordCount * _header.RecordSize));

            // Lire le bloc de chaînes de caractères
            _stringBlock = reader.ReadBytes((int)_header.StringBlockSize);
        }
    }

    public uint RecordCount => _header.RecordCount;
    public uint FieldCount => _header.FieldCount;
    public uint RecordSize => _header.RecordSize;

    public int GetInt32(int recordIndex, int fieldIndex)
    {
        if (recordIndex >= _header.RecordCount || fieldIndex >= _header.FieldCount)
            throw new ArgumentOutOfRangeException();

        int offset = recordIndex * (int)_header.RecordSize + fieldIndex * 4;
        return BitConverter.ToInt32(_data, offset);
    }

    public uint GetUInt32(int recordIndex, int fieldIndex)
    {
        if (recordIndex >= _header.RecordCount || fieldIndex >= _header.FieldCount)
            throw new ArgumentOutOfRangeException();

        int offset = recordIndex * (int)_header.RecordSize + fieldIndex * 4;
        return BitConverter.ToUInt32(_data, offset);
    }

    public float GetFloat(int recordIndex, int fieldIndex)
    {
        if (recordIndex >= _header.RecordCount || fieldIndex >= _header.FieldCount)
            throw new ArgumentOutOfRangeException();

        int offset = recordIndex * (int)_header.RecordSize + fieldIndex * 4;
        return BitConverter.ToSingle(_data, offset);
    }

    public string GetString(int recordIndex, int fieldIndex)
    {
        // Le champ contient un offset dans le bloc de chaînes
        uint stringOffset = GetUInt32(recordIndex, fieldIndex);

        if (stringOffset >= _header.StringBlockSize)
            return string.Empty;

        // Déterminer la fin de la chaîne (caractère nul)
        int endOffset = Array.IndexOf<byte>(_stringBlock, 0, (int)stringOffset);
        if (endOffset == -1)
            endOffset = _stringBlock.Length;

        int length = endOffset - (int)stringOffset;
        return Encoding.UTF8.GetString(_stringBlock, (int)stringOffset, length);
    }

    // Nouvelle méthode pour récupérer une chaîne localisée
    // Dans les fichiers DBC, les chaînes localisées sont généralement stockées dans des champs consécutifs
    public string GetLocalizedString(int recordIndex, int baseFieldIndex, LocaleConstant locale)
    {
        // Si la langue demandée est enUS (défaut) ou si la langue n'est pas valide, renvoyer le champ de base
        if (locale == LocaleConstant.LOCALE_EN_US || (byte)locale >= (byte)LocaleConstant.TOTAL_LOCALES)
            return GetString(recordIndex, baseFieldIndex);

        // Sinon, calculer l'index du champ pour la langue demandée
        // Les champs de langue sont généralement stockés à la suite du champ de base
        int localizedFieldIndex = baseFieldIndex + (int)locale;

        // Si l'index du champ localisé dépasse le nombre total de champs, renvoyer le champ de base
        if (localizedFieldIndex >= _header.FieldCount)
            return GetString(recordIndex, baseFieldIndex);

        // Récupérer la chaîne localisée
        string localizedString = GetString(recordIndex, localizedFieldIndex);

        // Si la chaîne localisée est vide, utiliser la chaîne par défaut (enUS)
        return string.IsNullOrEmpty(localizedString) ? GetString(recordIndex, baseFieldIndex) : localizedString;
    }
}