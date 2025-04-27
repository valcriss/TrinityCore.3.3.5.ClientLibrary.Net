namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Models.Social;

public class Contacts
{
    public List<Friend?> Friends { get; set; } = new();
    public List<Contact> Ignored { get; set; } = new();
    public List<Contact> Muted { get; set; } = new();

    public bool UpdateFriend(Friend update)
    {
        lock (Friends)
        {
            Friend? friend = Friends.FirstOrDefault(c => c?.Guid == update.Guid);
            if (friend == null) return false;
            friend.Level = update.Level;
            friend.Note = update.Note;
            friend.Status = update.Status;
            friend.Class = update.Class;
            friend.AreaId = update.AreaId;
            return true;
        }
    }

    public override string ToString()
    {
        return $"Friends: {string.Join(", ", Friends.Select(f => f?.ToString()))}, " +
               $"Ignored: {string.Join(", ", Ignored.Select(i => i.ToString()))}, " +
               $"Muted: {string.Join(", ", Muted.Select(m => m.ToString()))}";
    }
}