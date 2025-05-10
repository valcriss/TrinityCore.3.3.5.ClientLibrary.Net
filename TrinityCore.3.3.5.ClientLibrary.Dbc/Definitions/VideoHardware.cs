using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("VideoHardware.dbc")]
public class VideoHardware : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int VendorId { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int DeviceId { get; set; }

    [DbcColumn(3, DbcColumnDataType.Int32)]
    public int FarclipIdx { get; set; }

    [DbcColumn(4, DbcColumnDataType.Int32)]
    public int TerrainLODDistIdx { get; set; }

    [DbcColumn(5, DbcColumnDataType.Int32)]
    public int TerrainShadowLOD { get; set; }

    [DbcColumn(6, DbcColumnDataType.Int32)]
    public int DetailDoodadDensityIdx { get; set; }

    [DbcColumn(7, DbcColumnDataType.Int32)]
    public int DetailDoodadAlpha { get; set; }

    [DbcColumn(8, DbcColumnDataType.Int32)]
    public int AnimatingDoodadIdx { get; set; }

    [DbcColumn(9, DbcColumnDataType.Int32)]
    public int Trilinear { get; set; }

    [DbcColumn(10, DbcColumnDataType.Int32)]
    public int NumLights { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int Specularity { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int WaterLODIdx { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int ParticleDensityIdx { get; set; }

    [DbcColumn(14, DbcColumnDataType.Int32)]
    public int UnitDrawDistIdx { get; set; }

    [DbcColumn(15, DbcColumnDataType.Int32)]
    public int SmallCullDistIdx { get; set; }

    [DbcColumn(16, DbcColumnDataType.Int32)]
    public int ResolutionIdx { get; set; }

    [DbcColumn(17, DbcColumnDataType.Int32)]
    public int BaseMipLevel { get; set; }

    [DbcColumn(18, DbcColumnDataType.StringRef)]
    public string? OglOverrides { get; set; }

    [DbcColumn(19, DbcColumnDataType.StringRef)]
    public string? D3dOverrides { get; set; }

    [DbcColumn(20, DbcColumnDataType.Int32)]
    public int FixLag { get; set; }

    [DbcColumn(21, DbcColumnDataType.Int32)]
    public int Multisample { get; set; }

    [DbcColumn(22, DbcColumnDataType.Int32)]
    public int Atlasdisable { get; set; }
}