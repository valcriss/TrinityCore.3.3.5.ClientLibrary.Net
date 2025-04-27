namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Server;

public class TimeSpeedInfo
{
    public DateTime GameTime { get; set; }
    public int TimeHolidayOffset { get; set; }
    public float TimeSpeed { get; set; }

    public override string ToString()
    {
        return $"GameTime: {GameTime}, TimeSpeed: {TimeSpeed}, TimeHolidayOffset: {TimeHolidayOffset}";
    }
}