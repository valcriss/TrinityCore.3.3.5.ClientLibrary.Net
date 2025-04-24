namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Models.Results;

public class RealmListResult
{
    public List<Realm> Realms { get; set; }

    public RealmListResult(List<Realm> realms)
    {
        Realms = realms;
    }
}