using TrinityCore._3._3._5.ClientLibrary.Shared.Math;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Player;

public class WorldPoint
{
    public uint AreaId { get; set; }
    public uint MapId { get; set; }
    public Coord Position { get; set; }
    
    public override string ToString()
    {
        return $"MapId:{MapId}, AreaId:{AreaId}, Position:{Position}";
    }
}