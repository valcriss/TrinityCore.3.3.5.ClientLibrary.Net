using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;
using TrinityCore._3._3._5.ClientLibrary.Dbc.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions;

[DbcFile("Vehicle.dbc")]
public class Vehicle : DbcFile
{
    [DbcColumn(0, DbcColumnDataType.Int32)]
    public int Id { get; set; }

    [DbcColumn(1, DbcColumnDataType.Int32)]
    public int Flags { get; set; }

    [DbcColumn(2, DbcColumnDataType.Float)]
    public float TurnSpeed { get; set; }

    [DbcColumn(3, DbcColumnDataType.Float)]
    public float PitchSpeed { get; set; }

    [DbcColumn(4, DbcColumnDataType.Float)]
    public float PitchMin { get; set; }

    [DbcColumn(5, DbcColumnDataType.Float)]
    public float PitchMax { get; set; }

    [DbcColumn(6, DbcColumnDataType.ArrayOfUint32, 8)]
    public int[]? SeatId { get; set; }

    [DbcColumn(7, DbcColumnDataType.Float)]
    public float MouseLookOffsetPitch { get; set; }

    [DbcColumn(8, DbcColumnDataType.Float)]
    public float CameraFadeDistScalarMin { get; set; }

    [DbcColumn(9, DbcColumnDataType.Float)]
    public float CameraFadeDistScalarMax { get; set; }

    [DbcColumn(10, DbcColumnDataType.Float)]
    public float CameraPitchOffset { get; set; }

    [DbcColumn(11, DbcColumnDataType.Float)]
    public float FacingLimitRight { get; set; }

    [DbcColumn(12, DbcColumnDataType.Float)]
    public float FacingLimitLeft { get; set; }

    [DbcColumn(13, DbcColumnDataType.Float)]
    public float MsslTrgtTurnLingering { get; set; }

    [DbcColumn(14, DbcColumnDataType.Float)]
    public float MsslTrgtPitchLingering { get; set; }

    [DbcColumn(15, DbcColumnDataType.Float)]
    public float MsslTrgtMouseLingering { get; set; }

    [DbcColumn(16, DbcColumnDataType.Float)]
    public float MsslTrgtEndOpacity { get; set; }

    [DbcColumn(17, DbcColumnDataType.Float)]
    public float MsslTrgtArcSpeed { get; set; }

    [DbcColumn(18, DbcColumnDataType.Float)]
    public float MsslTrgtArcRepeat { get; set; }

    [DbcColumn(19, DbcColumnDataType.Float)]
    public float MsslTrgtArcWidth { get; set; }

    [DbcColumn(20, DbcColumnDataType.ArrayOfFloat, 2)]
    public float[]? MsslTrgtImpactRadius { get; set; }

    [DbcColumn(21, DbcColumnDataType.StringRef)]
    public string? MsslTrgtArcTexture { get; set; }

    [DbcColumn(22, DbcColumnDataType.StringRef)]
    public string? MsslTrgtImpactTexture { get; set; }

    [DbcColumn(23, DbcColumnDataType.ArrayOfStringRef, 2)]
    public string[]? MsslTrgtImpactModel { get; set; }

    [DbcColumn(24, DbcColumnDataType.Float)]
    public float CameraYawOffset { get; set; }

    [DbcColumn(25, DbcColumnDataType.Int32)]
    public int UiLocomotionType { get; set; }

    [DbcColumn(26, DbcColumnDataType.Float)]
    public float MsslTrgtImpactTexRadius { get; set; }

    [DbcColumn(27, DbcColumnDataType.Int32)]
    public int VehicleUIIndicatorId { get; set; }

    [DbcColumn(28, DbcColumnDataType.ArrayOfUint32, 3)]
    public int[]? PowerDisplayId { get; set; }

    public VehicleSeat[]? GetSeatIdVehicleSeats()
    {
        return DbcDirectory.Open<VehicleSeat>()?.Where(c => SeatId != null && SeatId.Contains(c.Id)).ToArray();
    }

    public VehicleUIIndicator? GetVehicleUIIndicatorIdVehicleUIIndicator()
    {
        return DbcDirectory.Open<VehicleUIIndicator>()?.Where(c => c.Id == VehicleUIIndicatorId).FirstOrDefault();
    }

    public PowerDisplay[]? GetPowerDisplayIdPowerDisplays()
    {
        return DbcDirectory.Open<PowerDisplay>()?.Where(c => PowerDisplayId != null && PowerDisplayId.Contains(c.Id)).ToArray();
    }
}