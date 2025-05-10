using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("Vehicle.dbc")]
    public class Vehicle : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int Flags { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Float)]
        public float TurnSpeed { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.Float)]
        public float PitchSpeed { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float PitchMin { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Float)]
        public float PitchMax { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.ArrayOfUint32, 8)]
        public int[]? SeatId { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Float)]
        public float MouseLookOffsetPitch { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Float)]
        public float CameraFadeDistScalarMin { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Float)]
        public float CameraFadeDistScalarMax { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Float)]
        public float CameraPitchOffset { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Float)]
        public float FacingLimitRight { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Float)]
        public float FacingLimitLeft { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Float)]
        public float MsslTrgtTurnLingering { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Float)]
        public float MsslTrgtPitchLingering { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.Float)]
        public float MsslTrgtMouseLingering { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.Float)]
        public float MsslTrgtEndOpacity { get; set; }

        [DbcColumn(17, Enums.DbcColumnDataType.Float)]
        public float MsslTrgtArcSpeed { get; set; }

        [DbcColumn(18, Enums.DbcColumnDataType.Float)]
        public float MsslTrgtArcRepeat { get; set; }

        [DbcColumn(19, Enums.DbcColumnDataType.Float)]
        public float MsslTrgtArcWidth { get; set; }

        [DbcColumn(20, Enums.DbcColumnDataType.ArrayOfFloat, 2)]
        public float[]? MsslTrgtImpactRadius { get; set; }

        [DbcColumn(21, Enums.DbcColumnDataType.StringRef)]
        public string? MsslTrgtArcTexture { get; set; }

        [DbcColumn(22, Enums.DbcColumnDataType.StringRef)]
        public string? MsslTrgtImpactTexture { get; set; }

        [DbcColumn(23, Enums.DbcColumnDataType.ArrayOfStringRef, 2)]
        public string[]? MsslTrgtImpactModel { get; set; }

        [DbcColumn(24, Enums.DbcColumnDataType.Float)]
        public float CameraYawOffset { get; set; }

        [DbcColumn(25, Enums.DbcColumnDataType.Int32)]
        public int UiLocomotionType { get; set; }

        [DbcColumn(26, Enums.DbcColumnDataType.Float)]
        public float MsslTrgtImpactTexRadius { get; set; }

        [DbcColumn(27, Enums.DbcColumnDataType.Int32)]
        public int VehicleUIIndicatorId { get; set; }

        [DbcColumn(28, Enums.DbcColumnDataType.ArrayOfUint32, 3)]
        public int[]? PowerDisplayId { get; set; }

        public VehicleSeat[]? GetSeatIdVehicleSeats()
        {
               return DbcDirectory.Open<VehicleSeat>()?.Where(c => this.SeatId != null && this.SeatId.Contains(c.Id)).ToArray();
        }

        public VehicleUIIndicator? GetVehicleUIIndicatorIdVehicleUIIndicator()
        {
               return DbcDirectory.Open<VehicleUIIndicator>()?.Where(c => c.Id == this.VehicleUIIndicatorId).FirstOrDefault();
        }

        public PowerDisplay[]? GetPowerDisplayIdPowerDisplays()
        {
               return DbcDirectory.Open<PowerDisplay>()?.Where(c => this.PowerDisplayId != null && this.PowerDisplayId.Contains(c.Id)).ToArray();
        }

     }
}
