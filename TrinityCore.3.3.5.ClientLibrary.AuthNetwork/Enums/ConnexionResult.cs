namespace TrinityCore._3._3._5.ClientLibrary.AuthNetwork.Enums;

public enum ConnexionResult : byte
{
    NONE = 0,
    LOGON_CHALLENGE_FAILED = 1,
    AUTH_PROOF_FAILED = 2,
    AUTH_INVALID_PROOF = 3,
    AUTHENTIFICATION_FAILED = 4,
    SUCCESS = 99,
}