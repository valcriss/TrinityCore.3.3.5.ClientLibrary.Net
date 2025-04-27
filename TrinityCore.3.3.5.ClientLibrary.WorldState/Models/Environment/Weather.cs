using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class Weather
{
    public WeatherState WeatherState { get; set; }
    public float Intensity { get; set; }
    public bool Abrupt { get; set; }
}