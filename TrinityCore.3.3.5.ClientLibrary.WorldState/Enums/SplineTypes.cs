namespace TrinityCore._3._3._5.ClientLibrary.WorldState.Enums;

[Flags]
public enum SplineTypes : uint
{
    NONE = 0x00000000,

    // x00-xFF(first byte) used as animation Ids storage in pair with Animation flag
    DONE = 0x00000100,

    FALLING = 0x00000200, // Affects elevation computation, can't be combined with Parabolic flag
    NO_SPLINE = 0x00000400,
    PARABOLIC = 0x00000800, // Affects elevation computation, can't be combined with Falling flag
    CAN_SWIM = 0x00001000,
    FLYING = 0x00002000, // Smooth movement(Catmullrom interpolation mode), flying animation
    ORIENTATION_FIXED = 0x00004000, // Model orientation fixed
    FINAL_POINT = 0x00008000,
    FINAL_TARGET = 0x00010000,
    FINAL_ANGLE = 0x00020000,
    CATMULLROM = 0x00040000, // Used Catmullrom interpolation mode
    CYCLIC = 0x00080000, // Movement by cycled spline
    ENTER_CYCLE = 0x00100000, // Everytimes appears with cyclic flag in monster move packet, erases first spline vertex after first cycle done
    ANIMATION = 0x00200000, // Plays animation after some time passed
    FROZEN = 0x00400000, // Will never arrive
    TRANSPORT_ENTER = 0x00800000,
    TRANSPORT_EXIT = 0x01000000,
    UNKNOWN7 = 0x02000000,
    UNKNOWN8 = 0x04000000,
    BACKWARD = 0x08000000,
    UNKNOWN10 = 0x10000000,
    UNKNOWN11 = 0x20000000,
    UNKNOWN12 = 0x40000000,
    UNKNOWN13 = 0x80000000,

    // Masks
    MASK_FINAL_FACING = FINAL_POINT | FINAL_TARGET | FINAL_ANGLE,

    // animation ids stored here, see AnimationTier enum, used with Animation flag
    MASK_ANIMATIONS = 0xFF,

    // flags that shouldn't be appended into SMSG_MONSTER_MOVE\SMSG_MONSTER_MOVE_TRANSPORT
    // packet, should be more probably
    MASK_NO_MONSTER_MOVE = MASK_FINAL_FACING | MASK_ANIMATIONS | DONE,

    // CatmullRom interpolation mode used
    MASK_CATMULL_ROM = FLYING | CATMULLROM,

    // Unused, not suported flags
    MASK_UNUSED = NO_SPLINE | ENTER_CYCLE | FROZEN | UNKNOWN7 | UNKNOWN8 | UNKNOWN10 | UNKNOWN11 | UNKNOWN12 | UNKNOWN13
}