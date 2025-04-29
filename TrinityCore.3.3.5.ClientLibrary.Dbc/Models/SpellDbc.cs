using TrinityCore._3._3._5.ClientLibrary.Dbc.Core;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Models;

public class SpellDbc : DbcReader
{
    private const int FIELD_ID = 0;
    private const int FIELD_NAME = 136; // Premier champ de la chaîne de nom (enUS)
    private const int FIELD_RANK = 137; // Premier champ du rang/sous-texte (enUS)
    private const int FIELD_DESCRIPTION = 138; // Premier champ de la description (enUS)
    private const int FIELD_TOOLTIP = 139; // Premier champ de l'info-bulle (enUS)
    private readonly LocaleConstant _defaultLocale;

    private readonly Dictionary<int, SpellEntry> _spellEntries = new();

    public SpellDbc(string filePath, LocaleConstant locale = LocaleConstant.LOCALE_EN_US) : base(filePath, locale)
    {
        _defaultLocale = locale;
        LoadSpells();
    }

    public SpellEntry? GetSpellById(int spellId)
    {
        return _spellEntries.GetValueOrDefault(spellId);
    }

    public IEnumerable<SpellEntry> GetAllSpells()
    {
        return _spellEntries.Values;
    }

    public IEnumerable<SpellEntry> SearchSpellsByName(string nameFragment)
    {
        List<SpellEntry> results = new();

        foreach (SpellEntry entry in _spellEntries.Values)
            if (entry.Name.Contains(nameFragment, StringComparison.OrdinalIgnoreCase))
                results.Add(entry);

        return results;
    }

    private void LoadSpells()
    {
        for (int i = 0; i < RecordCount; i++)
        {
            SpellEntry entry = new()
            {
                Id = GetInt32(i, FIELD_ID),
                Name = GetLocalizedString(i, FIELD_NAME, _defaultLocale),
                NameSubtext = GetLocalizedString(i, FIELD_RANK, _defaultLocale),
                Description = GetLocalizedString(i, FIELD_DESCRIPTION, _defaultLocale),
                ToolTip = GetLocalizedString(i, FIELD_TOOLTIP, _defaultLocale)
            };

            _spellEntries[entry.Id] = entry;
        }
    }
}