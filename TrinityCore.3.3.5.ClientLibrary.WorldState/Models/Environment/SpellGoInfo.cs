using TrinityCore._3._3._5.ClientLibrary.Shared.Math;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class SpellGoInfo
{
    // Informations générales du sort
    public ulong CasterGUID { get; set; }
    public ulong CasterUnitGUID { get; set; }
    public uint SpellID { get; set; }
    public uint CastFlags { get; set; }
    public uint CastFlagsEx { get; set; }
    public uint CastTime { get; set; }

    // Informations de cible
    public List<ulong> HitTargets { get; set; } = [];
    public List<ulong> MissTargets { get; set; } = [];
    public List<SpellMissInfo> MissStatus { get; set; } = [];

    // Informations de destination
    public Coord? TargetPosition { get; set; }
    public ulong TargetGUID { get; set; }

    // Informations de puissance
    public SpellPowerData PowerData { get; set; } = new();

    // Informations d'item
    public uint ItemTargetEntry { get; set; }

    // Targets prédits
    public List<ulong> PredictedTargets { get; set; } = [];

    // Flags supplémentaires
    public bool HasDestLocation { get; set; }
    public bool HasTargetMask { get; set; }
    public bool HasExtraTargets { get; set; }
    public uint TargetMask { get; set; }

    public List<SpellExtraTarget> ExtraTargets { get; set; } = [];

    public override string ToString()
    {
        return $"SpellGo: ID={SpellID}, Caster={CasterGUID:X16}, Targets={HitTargets.Count}";
    }
}