﻿namespace TrinityCore._3._3._5.ClientLibrary.WorldNetwork.Models.Enums;

public enum CommandDetail : byte
{
    AUTH_OK = 12,
    AUTH_FAILED = 13,
    AUTH_REJECT = 14,
    AUTH_BAD_SERVER_PROOF = 15,
    AUTH_UNAVAILABLE = 16,
    AUTH_SYSTEM_ERROR = 17,
    AUTH_BILLING_ERROR = 18,
    AUTH_BILLING_EXPIRED = 19,
    AUTH_VERSION_MISMATCH = 20,
    AUTH_UNKNOWN_ACCOUNT = 21,
    AUTH_INCORRECT_PASSWORD = 22,
    AUTH_SESSION_EXPIRED = 23,
    AUTH_SERVER_SHUTTING_DOWN = 24,
    AUTH_ALREADY_LOGGING_IN = 25,
    AUTH_LOGIN_SERVER_NOT_FOUND = 26,
    AUTH_WAIT_QUEUE = 27,
    AUTH_BANNED = 28,
    AUTH_ALREADY_ONLINE = 29,
    AUTH_NO_TIME = 30,
    AUTH_DB_BUSY = 31,
    AUTH_SUSPENDED = 32,
    AUTH_PARENTAL_CONTROL = 33,
    AUTH_LOCKED_ENFORCED = 34,

    CHAR_CREATE_IN_PROGRESS = 46,
    CHAR_CREATE_SUCCESS = 47,
    CHAR_CREATE_ERROR = 48,
    CHAR_CREATE_FAILED = 49,
    CHAR_CREATE_NAME_IN_USE = 50,
    CHAR_CREATE_DISABLED = 51,
    CHAR_CREATE_PVP_TEAMS_VIOLATION = 52,
    CHAR_CREATE_SERVER_LIMIT = 53,
    CHAR_CREATE_ACCOUNT_LIMIT = 54,
    CHAR_CREATE_SERVER_QUEUE = 55,
    CHAR_CREATE_ONLY_EXISTING = 56,
    CHAR_CREATE_EXPANSION = 57,
    CHAR_CREATE_EXPANSION_CLASS = 58,
    CHAR_CREATE_LEVEL_REQUIREMENT = 59,
    CHAR_CREATE_UNIQUE_CLASS_LIMIT = 60,
    CHAR_CREATE_CHARACTER_IN_GUILD = 61,
    CHAR_CREATE_RESTRICTED_RACECLASS = 62,
    CHAR_CREATE_CHARACTER_CHOOSE_RACE = 63,
    CHAR_CREATE_CHARACTER_ARENA_LEADER = 64,
    CHAR_CREATE_CHARACTER_DELETE_MAIL = 65,
    CHAR_CREATE_CHARACTER_SWAP_FACTION = 66,
    CHAR_CREATE_CHARACTER_RACE_ONLY = 67,
    CHAR_CREATE_CHARACTER_GOLD_LIMIT = 68,
    CHAR_CREATE_FORCE_LOGIN = 69,

    CHAR_NAME_SUCCESS = 87,
    CHAR_NAME_FAILURE = 88,
    CHAR_NAME_NO_NAME = 89,
    CHAR_NAME_TOO_SHORT = 90,
    CHAR_NAME_TOO_LONG = 91,
    CHAR_NAME_INVALID_CHARACTER = 92,
    CHAR_NAME_MIXED_LANGUAGES = 93,
    CHAR_NAME_PROFANE = 94,
    CHAR_NAME_RESERVED = 95,
    CHAR_NAME_INVALID_APOSTROPHE = 96,
    CHAR_NAME_MULTIPLE_APOSTROPHES = 97,
    CHAR_NAME_THREE_CONSECUTIVE = 98,
    CHAR_NAME_INVALID_SPACE = 99,
    CHAR_NAME_CONSECUTIVE_SPACES = 100,
    CHAR_NAME_RUSSIAN_CONSECUTIVE_SILENT_CHARACTERS = 101,
    CHAR_NAME_RUSSIAN_SILENT_CHARACTER_AT_BEGINNING_OR_END = 102,
    CHAR_NAME_DECLENSION_DOESNT_MATCH_BASE_NAME = 103
}