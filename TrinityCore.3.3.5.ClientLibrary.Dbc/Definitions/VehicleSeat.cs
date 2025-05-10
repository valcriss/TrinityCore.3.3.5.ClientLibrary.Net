using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("VehicleSeat.dbc")]
public class VehicleSeat : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Float)]
    public float Field33512213001 { get; set; }

    [DbcColumn(2, DbcColumnDataType.Int32)]
    public int AttachmentId { get; set; }

    [DbcColumn(3, DbcColumnDataType.ArrayOfFloat, 3)]
    public float[]? AttachmentOffset { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float Field33512213004 { get; set; }

    [DbcColumn(5, DbcColumnDataType.Float)]
    public float EnterSpeed { get; set; }

    [DbcColumn(6, DbcColumnDataType.Float)]
    public float EnterGravity { get; set; }

    [DbcColumn(7, DbcColumnDataType.Float)]
    public float EnterMinDuration { get; set; }

    [DbcColumn(8, DbcColumnDataType.Float)]
    public float EnterMaxDuration { get; set; }

    [DbcColumn(9, DbcColumnDataType.Float)]
    public float EnterMinArcHeight { get; set; }

    [DbcColumn(10, DbcColumnDataType.Float)]
    public float EnterMaxArcHeight { get; set; }

    [DbcColumn(11, DbcColumnDataType.Int32)]
    public int EnterAnimStart { get; set; }

    [DbcColumn(12, DbcColumnDataType.Int32)]
    public int EnterAnimLoop { get; set; }

    [DbcColumn(13, DbcColumnDataType.Int32)]
    public int RideAnimStart { get; set; }

    [DbcColumn(14, DbcColumnDataType.Int32)]
    public int RideAnimLoop { get; set; }

    [DbcColumn(15, DbcColumnDataType.Int32)]
    public int RideUpperAnimStart { get; set; }

    [DbcColumn(16, DbcColumnDataType.Int32)]
    public int RideUpperAnimLoop { get; set; }

    [DbcColumn(17, DbcColumnDataType.Float)]
    public float Field33512213017 { get; set; }

    [DbcColumn(18, DbcColumnDataType.Float)]
    public float ExitSpeed { get; set; }

    [DbcColumn(19, DbcColumnDataType.Float)]
    public float ExitGravity { get; set; }

    [DbcColumn(20, DbcColumnDataType.Float)]
    public float ExitMinDuration { get; set; }

    [DbcColumn(21, DbcColumnDataType.Float)]
    public float ExitMaxDuration { get; set; }

    [DbcColumn(22, DbcColumnDataType.Float)]
    public float ExitMinArcHeight { get; set; }

    [DbcColumn(23, DbcColumnDataType.Float)]
    public float ExitMaxArcHeight { get; set; }

    [DbcColumn(24, DbcColumnDataType.Int32)]
    public int ExitAnimStart { get; set; }

    [DbcColumn(25, DbcColumnDataType.Int32)]
    public int ExitAnimLoop { get; set; }

    [DbcColumn(26, DbcColumnDataType.Int32)]
    public int ExitAnimEnd { get; set; }

    [DbcColumn(27, DbcColumnDataType.Float)]
    public float Field33512213027 { get; set; }

    [DbcColumn(28, DbcColumnDataType.Float)]
    public float PassengerPitch { get; set; }

    [DbcColumn(29, DbcColumnDataType.Float)]
    public float Field33512213029 { get; set; }

    [DbcColumn(30, DbcColumnDataType.Int32)]
    public int PassengerAttachmentId { get; set; }

    [DbcColumn(31, DbcColumnDataType.Int32)]
    public int VehicleEnterAnim { get; set; }

    [DbcColumn(32, DbcColumnDataType.Int32)]
    public int VehicleExitAnim { get; set; }

    [DbcColumn(33, DbcColumnDataType.Int32)]
    public int VehicleRideAnimLoop { get; set; }

    [DbcColumn(34, DbcColumnDataType.Int32)]
    public int Field33512213034 { get; set; }

    [DbcColumn(35, DbcColumnDataType.Int32)]
    public int VehicleExitAnimBone { get; set; }

    [DbcColumn(36, DbcColumnDataType.Int32)]
    public int VehicleEnterAnimBone { get; set; }

    [DbcColumn(37, DbcColumnDataType.Float)]
    public float Field33512213037 { get; set; }

    [DbcColumn(38, DbcColumnDataType.Float)]
    public float Field33512213038 { get; set; }

    [DbcColumn(39, DbcColumnDataType.Int32)]
    public int VehicleAbilityDisplay { get; set; }

    [DbcColumn(40, DbcColumnDataType.Int32)]
    public int EnterUISoundId { get; set; }

    [DbcColumn(41, DbcColumnDataType.Int32)]
    public int Field33512213041 { get; set; }

    [DbcColumn(42, DbcColumnDataType.Int32)]
    public int UiSkin { get; set; }

    [DbcColumn(43, DbcColumnDataType.Float)]
    public float Field33512213043 { get; set; }

    [DbcColumn(44, DbcColumnDataType.Float)]
    public float Field33512213044 { get; set; }

    [DbcColumn(45, DbcColumnDataType.Float)]
    public float Field33512213045 { get; set; }

    [DbcColumn(46, DbcColumnDataType.Int32)]
    public int Field33512213046 { get; set; }

    [DbcColumn(47, DbcColumnDataType.Float)]
    public float Field33512213047 { get; set; }

    [DbcColumn(48, DbcColumnDataType.Float)]
    public float Field33512213048 { get; set; }

    [DbcColumn(49, DbcColumnDataType.Float)]
    public float Field33512213049 { get; set; }

    [DbcColumn(50, DbcColumnDataType.Float)]
    public float Field33512213050 { get; set; }

    [DbcColumn(51, DbcColumnDataType.Float)]
    public float Field33512213051 { get; set; }

    [DbcColumn(52, DbcColumnDataType.Float)]
    public float Field33512213052 { get; set; }

    [DbcColumn(53, DbcColumnDataType.Float)]
    public float Field33512213053 { get; set; }

    [DbcColumn(54, DbcColumnDataType.Float)]
    public float Field33512213054 { get; set; }

    [DbcColumn(55, DbcColumnDataType.Float)]
    public float Field33512213055 { get; set; }

    public SoundEntries? GetEnterUISoundIdSoundEntries()
    {
        return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == EnterUISoundId).FirstOrDefault();
    }
}