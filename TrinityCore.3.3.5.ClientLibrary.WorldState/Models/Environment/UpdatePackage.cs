namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class UpdatePackage
{
    public List<UpdateObjectValues> UpdateValues { get; set; } = new();
    public List<UpdateCreateObject> UpdateOrCreateObjects { get; set; } = new();
    public List<UpdateMovement> UpdateMovements { get; set; } = new();
    public List<UpdateOutOfRange> UpdateOutOfRange { get; set; } = new();
}