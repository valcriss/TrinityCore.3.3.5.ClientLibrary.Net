using TrinityCore._3._3._5.ClientLibrary.Shared.Logger;
using TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Environment;

public class EntitiesCollection
{
    private readonly Dictionary<ulong, Entity> _entities = new();
    private readonly List<QuestGiverInfo> _questGivers = new();

    public void Update(UpdatePackage updatePackage)
    {
        foreach (UpdateCreateObject updateCreateObject in updatePackage.UpdateOrCreateObjects) ProcessUpdateOrCreateObject(updateCreateObject);

        foreach (UpdateObjectValues updateObjectValues in updatePackage.UpdateValues) ProcessUpdateObjectValues(updateObjectValues);

        foreach (UpdateMovement updateMovement in updatePackage.UpdateMovements) ProcessUpdateMovement(updateMovement);

        foreach (UpdateOutOfRange updateOutOfRange in updatePackage.UpdateOutOfRange) ProcessUpdateOutOfRange(updateOutOfRange);
    }

    private void ProcessUpdateOutOfRange(UpdateOutOfRange updateOutOfRange)
    {
        foreach (ulong outOfRangeGuid in updateOutOfRange.OutOfRangeGuids) DestroyEntity(outOfRangeGuid);
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

    public void UpdateQuestGiverMultiple(QuestGiverInfoMultiple questGiverInfoMultiple)
    {
        foreach (QuestGiverInfo questGiverInfo in questGiverInfoMultiple.Infos) UpdateQuestGiver(questGiverInfo);
    }

    public void UpdateQuestGiver(QuestGiverInfo questGiverInfo)
    {
        if (!_entities.TryGetValue(questGiverInfo.QuestGiverGuid, out Entity? entity))
        {
            Log.Warn($" QuestGiverInfo {questGiverInfo.QuestGiverGuid} not found in entities collection.");
            return;
        }

        QuestGiverInfo? existingQuestGiverInfo = _questGivers.FirstOrDefault(q => q.QuestGiverGuid == questGiverInfo.QuestGiverGuid);
        if (existingQuestGiverInfo != null)
        {
            if (questGiverInfo.Status == QuestGiverStatus.DIALOG_STATUS_NONE || questGiverInfo.Status == QuestGiverStatus.DIALOG_STATUS_UNAVAILABLE)
            {
                Log.Debug($"Removing quest giver: {questGiverInfo.QuestGiverGuid} with status {questGiverInfo.Status}");
                _questGivers.Remove(existingQuestGiverInfo);
                return;
            }

            Log.Debug($"Updating quest giver: {questGiverInfo.QuestGiverGuid} with status {questGiverInfo.Status}");
            existingQuestGiverInfo.Status = questGiverInfo.Status;
            return;
        }

        if (questGiverInfo.Status != QuestGiverStatus.DIALOG_STATUS_NONE && questGiverInfo.Status != QuestGiverStatus.DIALOG_STATUS_UNAVAILABLE)
        {
            Log.Debug($"Adding quest giver: {questGiverInfo.QuestGiverGuid} with status {questGiverInfo.Status}");
            _questGivers.Add(questGiverInfo);
        }
    }

    public void DestroyObject(DestroyObject destroyObject)
    {
        DestroyEntity(destroyObject.Guid);
    }

    private void DestroyEntity(ulong guid)
    {
        if (_entities.Remove(guid, out Entity? entity))
            _questGivers.RemoveAll(q => q.QuestGiverGuid == guid);
        else
            Log.Warn($"DestroyEntity {guid} not found in entities collection.");
    }

    public void UpdateThreat(ThreatData threatData)
    {
        if (!_entities.TryGetValue(threatData.Guid, out Entity? entity))
        {
            Log.Warn($"Entity {threatData.Guid} not found in entities collection for threat update.");
            return;
        }

        entity.UpdateThreat(threatData);
    }

    public void UpdateReaction(AiReaction aiReaction)
    {
        if (!_entities.TryGetValue(aiReaction.Guid, out Entity? entity))
        {
            Log.Warn($"Entity {aiReaction.Guid} not found in entities collection for ai reaction update.");
            return;
        }

        entity.UpdateAiReaction(aiReaction);
    }

    public void UpdateMovement(MovementUpdate movementUpdate)
    {
        if (!_entities.TryGetValue(movementUpdate.Guid, out Entity? entity))
        {
            Log.Warn($"Entity {movementUpdate.Guid} not found in entities collection for movement update.");
            return;
        }

        entity.UpdateMovement(movementUpdate);
    }

    public void UpdateAttackStart(AttackStartInfo attackStartInfo)
    {
        if (!_entities.TryGetValue(attackStartInfo.Guid, out Entity? entity))
        {
            Log.Warn($"Entity {attackStartInfo.Guid} not found in entities collection for attack start update.");
            return;
        }

        entity.UpdateAttackStart(attackStartInfo);
    }

    public void UpdateAttackStop(AttackStopInfo attackStopInfo)
    {
        if (!_entities.TryGetValue(attackStopInfo.Guid, out Entity? entity))
        {
            Log.Warn($"Entity {attackStopInfo.Guid} not found in entities collection for attack stop update.");
            return;
        }

        entity.UpdateAttackStop(attackStopInfo);
    }

    public void ClearThreat(ThreatClear threatClear)
    {
        if (!_entities.TryGetValue(threatClear.Guid, out Entity? entity))
        {
            Log.Warn($"Entity {threatClear.Guid} not found in entities collection for threat clear.");
            return;
        }

        entity.ClearThreat();
    }
}