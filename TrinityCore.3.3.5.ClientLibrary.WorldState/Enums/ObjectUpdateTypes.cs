namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

[Flags]
public enum ObjectUpdateTypes
{
    UPDATETYPE_VALUES = 0,
    UPDATETYPE_MOVEMENT = 1,
    UPDATETYPE_CREATE_OBJECT = 2,
    UPDATETYPE_CREATE_OBJECT2 = 3,
    UPDATETYPE_OUT_OF_RANGE_OBJECTS = 4,
    UPDATETYPE_NEAR_OBJECTS = 5
}