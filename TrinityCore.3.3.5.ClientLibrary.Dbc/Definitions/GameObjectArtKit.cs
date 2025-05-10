using TrinityCore._3._3._5.ClientLibrary.Dbc.Attributes;

namespace TrinityCore._3._3._5.ClientLibrary.Dbc.Definitions
{
    [DbcFile("GameObjectArtKit.dbc")]
    public class GameObjectArtKit : DbcFile
    {
        [DbcColumn(0, Enums.DbcColumnDataType.Int32)]
        public int Id { get; set; }

        [DbcColumn(1, Enums.DbcColumnDataType.ArrayOfStringRef, 3)]
        public string[]? TextureVariation { get; set; }

        [DbcColumn(2, Enums.DbcColumnDataType.ArrayOfStringRef, 4)]
        public string[]? AttachModel { get; set; }

     }
}
