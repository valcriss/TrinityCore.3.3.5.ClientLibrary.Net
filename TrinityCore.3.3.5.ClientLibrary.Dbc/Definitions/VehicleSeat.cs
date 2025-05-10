using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("VehicleSeat.dbc")]
    public class VehicleSeat : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Float)]
        public float Field33512213001 { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int AttachmentId { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfFloat, 3)]
        public float[]? AttachmentOffset { get; set; }

        [DbcColumn(4, Enums.DbcColumnDataType.Float)]
        public float Field33512213004 { get; set; }

        [DbcColumn(5, Enums.DbcColumnDataType.Float)]
        public float EnterSpeed { get; set; }

        [DbcColumn(6, Enums.DbcColumnDataType.Float)]
        public float EnterGravity { get; set; }

        [DbcColumn(7, Enums.DbcColumnDataType.Float)]
        public float EnterMinDuration { get; set; }

        [DbcColumn(8, Enums.DbcColumnDataType.Float)]
        public float EnterMaxDuration { get; set; }

        [DbcColumn(9, Enums.DbcColumnDataType.Float)]
        public float EnterMinArcHeight { get; set; }

        [DbcColumn(10, Enums.DbcColumnDataType.Float)]
        public float EnterMaxArcHeight { get; set; }

        [DbcColumn(11, Enums.DbcColumnDataType.Int32)]
        public int EnterAnimStart { get; set; }

        [DbcColumn(12, Enums.DbcColumnDataType.Int32)]
        public int EnterAnimLoop { get; set; }

        [DbcColumn(13, Enums.DbcColumnDataType.Int32)]
        public int RideAnimStart { get; set; }

        [DbcColumn(14, Enums.DbcColumnDataType.Int32)]
        public int RideAnimLoop { get; set; }

        [DbcColumn(15, Enums.DbcColumnDataType.Int32)]
        public int RideUpperAnimStart { get; set; }

        [DbcColumn(16, Enums.DbcColumnDataType.Int32)]
        public int RideUpperAnimLoop { get; set; }

        [DbcColumn(17, Enums.DbcColumnDataType.Float)]
        public float Field33512213017 { get; set; }

        [DbcColumn(18, Enums.DbcColumnDataType.Float)]
        public float ExitSpeed { get; set; }

        [DbcColumn(19, Enums.DbcColumnDataType.Float)]
        public float ExitGravity { get; set; }

        [DbcColumn(20, Enums.DbcColumnDataType.Float)]
        public float ExitMinDuration { get; set; }

        [DbcColumn(21, Enums.DbcColumnDataType.Float)]
        public float ExitMaxDuration { get; set; }

        [DbcColumn(22, Enums.DbcColumnDataType.Float)]
        public float ExitMinArcHeight { get; set; }

        [DbcColumn(23, Enums.DbcColumnDataType.Float)]
        public float ExitMaxArcHeight { get; set; }

        [DbcColumn(24, Enums.DbcColumnDataType.Int32)]
        public int ExitAnimStart { get; set; }

        [DbcColumn(25, Enums.DbcColumnDataType.Int32)]
        public int ExitAnimLoop { get; set; }

        [DbcColumn(26, Enums.DbcColumnDataType.Int32)]
        public int ExitAnimEnd { get; set; }

        [DbcColumn(27, Enums.DbcColumnDataType.Float)]
        public float Field33512213027 { get; set; }

        [DbcColumn(28, Enums.DbcColumnDataType.Float)]
        public float PassengerPitch { get; set; }

        [DbcColumn(29, Enums.DbcColumnDataType.Float)]
        public float Field33512213029 { get; set; }

        [DbcColumn(30, Enums.DbcColumnDataType.Int32)]
        public int PassengerAttachmentId { get; set; }

        [DbcColumn(31, Enums.DbcColumnDataType.Int32)]
        public int VehicleEnterAnim { get; set; }

        [DbcColumn(32, Enums.DbcColumnDataType.Int32)]
        public int VehicleExitAnim { get; set; }

        [DbcColumn(33, Enums.DbcColumnDataType.Int32)]
        public int VehicleRideAnimLoop { get; set; }

        [DbcColumn(34, Enums.DbcColumnDataType.Int32)]
        public int Field33512213034 { get; set; }

        [DbcColumn(35, Enums.DbcColumnDataType.Int32)]
        public int VehicleExitAnimBone { get; set; }

        [DbcColumn(36, Enums.DbcColumnDataType.Int32)]
        public int VehicleEnterAnimBone { get; set; }

        [DbcColumn(37, Enums.DbcColumnDataType.Float)]
        public float Field33512213037 { get; set; }

        [DbcColumn(38, Enums.DbcColumnDataType.Float)]
        public float Field33512213038 { get; set; }

        [DbcColumn(39, Enums.DbcColumnDataType.Int32)]
        public int VehicleAbilityDisplay { get; set; }

        [DbcColumn(40, Enums.DbcColumnDataType.Int32)]
        public int EnterUISoundId { get; set; }

        [DbcColumn(41, Enums.DbcColumnDataType.Int32)]
        public int Field33512213041 { get; set; }

        [DbcColumn(42, Enums.DbcColumnDataType.Int32)]
        public int UiSkin { get; set; }

        [DbcColumn(43, Enums.DbcColumnDataType.Float)]
        public float Field33512213043 { get; set; }

        [DbcColumn(44, Enums.DbcColumnDataType.Float)]
        public float Field33512213044 { get; set; }

        [DbcColumn(45, Enums.DbcColumnDataType.Float)]
        public float Field33512213045 { get; set; }

        [DbcColumn(46, Enums.DbcColumnDataType.Int32)]
        public int Field33512213046 { get; set; }

        [DbcColumn(47, Enums.DbcColumnDataType.Float)]
        public float Field33512213047 { get; set; }

        [DbcColumn(48, Enums.DbcColumnDataType.Float)]
        public float Field33512213048 { get; set; }

        [DbcColumn(49, Enums.DbcColumnDataType.Float)]
        public float Field33512213049 { get; set; }

        [DbcColumn(50, Enums.DbcColumnDataType.Float)]
        public float Field33512213050 { get; set; }

        [DbcColumn(51, Enums.DbcColumnDataType.Float)]
        public float Field33512213051 { get; set; }

        [DbcColumn(52, Enums.DbcColumnDataType.Float)]
        public float Field33512213052 { get; set; }

        [DbcColumn(53, Enums.DbcColumnDataType.Float)]
        public float Field33512213053 { get; set; }

        [DbcColumn(54, Enums.DbcColumnDataType.Float)]
        public float Field33512213054 { get; set; }

        [DbcColumn(55, Enums.DbcColumnDataType.Float)]
        public float Field33512213055 { get; set; }

        public SoundEntries? GetEnterUISoundIdSoundEntries()
        {
               return DbcDirectory.Open<SoundEntries>()?.Where(c => c.Id == this.EnterUISoundId).FirstOrDefault();
        }

     }
}
