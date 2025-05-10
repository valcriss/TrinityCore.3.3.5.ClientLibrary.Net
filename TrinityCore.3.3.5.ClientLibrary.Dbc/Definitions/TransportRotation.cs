using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("TransportRotation.dbc")]
    public class TransportRotation : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.Int32)]
        public int GameObjectsId { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.Int32)]
        public int TimeIndex { get; set; }

        [DbcColumn(3, Enums.DbcColumnDataType.ArrayOfFloat, 4)]
        public float[]? Rot { get; set; }

     }
}
