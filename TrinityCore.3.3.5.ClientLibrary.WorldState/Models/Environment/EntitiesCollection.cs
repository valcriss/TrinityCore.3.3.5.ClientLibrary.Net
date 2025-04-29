namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class EntitiesCollection
{
    private readonly Dictionary<ulong, Entity> _entities = new();

    public void Update(UpdatePackage updatePackage)
    {
        foreach (UpdateCreateObject updateCreateObject in updatePackage.UpdateOrCreateObjects) ProcessUpdateOrCreateObject(updateCreateObject);

        foreach (UpdateObjectValues updateObjectValues in updatePackage.UpdateValues) ProcessUpdateObjectValues(updateObjectValues);

        foreach (UpdateMovement updateMovement in updatePackage.UpdateMovements) ProcessUpdateMovement(updateMovement);

        foreach (UpdateOutOfRange updateOutOfRange in updatePackage.UpdateOutOfRange) ProcessUpdateOutOfRange(updateOutOfRange);
    }

    private void ProcessUpdateOutOfRange(UpdateOutOfRange updateOutOfRange)
    {
        foreach (ulong outOfRangeGuid in updateOutOfRange.OutOfRangeGuids) _entities.Remove(outOfRangeGuid);
    }

    private void ProcessUpdateObjectValues(UpdateObjectValues updateObjectValues)
    {
        if (_entities.TryGetValue(updateObjectValues.Guid, out Entity? entity)) entity.UpdateValues(updateObjectValues.Values);
    }

    private void ProcessUpdateOrCreateObject(UpdateCreateObject updateCreateObject)
    {
        if (!_entities.ContainsKey(updateCreateObject.Guid)) _entities[updateCreateObject.Guid] = new Entity();
        Entity entity = _entities[updateCreateObject.Guid];
        entity.Guid = updateCreateObject.Guid;
        entity.ObjectType = updateCreateObject.ObjectType;
        entity.UpdateValues(updateCreateObject.Values);
        entity.UpdateMovement(updateCreateObject.Movement);
    }

    private void ProcessUpdateMovement(UpdateMovement updateMovement)
    {
        if (_entities.TryGetValue(updateMovement.Guid, out Entity? entity)) entity.UpdateMovement(updateMovement.Movement);
    }

    public void UpdateMove(MonsterMoveData monsterMoveData)
    {
        if (_entities.TryGetValue(monsterMoveData.MoverGuid, out Entity? entity)) entity.UpdateMove(monsterMoveData);
    }
}