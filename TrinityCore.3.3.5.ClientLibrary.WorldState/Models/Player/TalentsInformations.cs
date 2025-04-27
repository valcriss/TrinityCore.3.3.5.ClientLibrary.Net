namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

public class TalentsInformations
{
    public List<Glyph> Glyphs { get; set; } = new();
    public bool IsPet { get; set; }
    public List<Talent> Talents { get; set; } = new();
    public uint UnSpendPoints { get; set; }
}

public class PetTalentsInformations : TalentsInformations
{
    public PetTalentsInformations()
    {
    }

    public PetTalentsInformations(TalentsInformations informations)
    {
        Glyphs = informations.Glyphs;
        IsPet = informations.IsPet;
        Talents = informations.Talents;
        UnSpendPoints = informations.UnSpendPoints;
    }
}

public class PlayerTalentsInformations : TalentsInformations
{
    public PlayerTalentsInformations()
    {
    }

    public PlayerTalentsInformations(TalentsInformations informations)
    {
        Glyphs = informations.Glyphs;
        IsPet = informations.IsPet;
        Talents = informations.Talents;
        UnSpendPoints = informations.UnSpendPoints;
    }
}