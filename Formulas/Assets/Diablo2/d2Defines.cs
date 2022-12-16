using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace d2
{
    public enum SpellFlag 
    {
        // clang-format off
        None         = 0,
        Etherealize  = 1 << 0,
        RageActive   = 1 << 1,
        RageCooldown = 1 << 2,
        // bits 3-7 are unused
        // clang-format on
    };

    public enum spell_type 
    {
        RSPLTYPE_SKILL,
        RSPLTYPE_SPELL,
        RSPLTYPE_SCROLL,
        RSPLTYPE_CHARGES,
        RSPLTYPE_INVALID,
    };

    public enum spell_id
    {
        SPL_NULL,
        SPL_FIREBOLT,
        SPL_HEAL,
        SPL_LIGHTNING,
        SPL_FLASH,
        SPL_IDENTIFY,
        SPL_FIREWALL,
        SPL_TOWN,
        SPL_STONE,
        SPL_INFRA,
        SPL_RNDTELEPORT,
        SPL_MANASHIELD,
        SPL_FIREBALL,
        SPL_GUARDIAN,
        SPL_CHAIN,
        SPL_WAVE,
        SPL_DOOMSERP,
        SPL_BLODRIT,
        SPL_NOVA,
        SPL_INVISIBIL,
        SPL_FLAME,
        SPL_GOLEM,
        SPL_BLODBOIL,
        SPL_TELEPORT,
        SPL_APOCA,
        SPL_ETHEREALIZE,
        SPL_REPAIR,
        SPL_RECHARGE,
        SPL_DISARM,
        SPL_ELEMENT,
        SPL_CBOLT,
        SPL_HBOLT,
        SPL_RESURRECT,
        SPL_TELEKINESIS,
        SPL_HEALOTHER,
        SPL_FLARE,
        SPL_BONESPIRIT,
        SPL_LASTDIABLO = SPL_BONESPIRIT,
        SPL_MANA,
        SPL_MAGI,
        SPL_JESTER,
        SPL_LIGHTWALL,
        SPL_IMMOLAT,
        SPL_WARP,
        SPL_REFLECT,
        SPL_BERSERK,
        SPL_FIRERING,
        SPL_SEARCH,
        SPL_RUNEFIRE,
        SPL_RUNELIGHT,
        SPL_RUNENOVA,
        SPL_RUNEIMMOLAT,
        SPL_RUNESTONE,

        SPL_LAST = SPL_RUNESTONE,
        SPL_INVALID = -1,
    };

    public enum _difficulty 
    {
        DIFF_NORMAL,
        DIFF_NIGHTMARE,
        DIFF_HELL,

        DIFF_LAST = DIFF_HELL,
    };

    public class d2DEF
    {
        public const int BaseHitChance = 50;
        public const bool gbIsHellfire = false;
    }

    public enum _monster_id
    {
        MT_NZOMBIE,
        MT_BZOMBIE,
        MT_GZOMBIE,
        MT_YZOMBIE,
        MT_RFALLSP,
        MT_DFALLSP,
        MT_YFALLSP,
        MT_BFALLSP,
        MT_WSKELAX,
        MT_TSKELAX,
        MT_RSKELAX,
        MT_XSKELAX,
        MT_RFALLSD,
        MT_DFALLSD,
        MT_YFALLSD,
        MT_BFALLSD,
        MT_NSCAV,
        MT_BSCAV,
        MT_WSCAV,
        MT_YSCAV,
        MT_WSKELBW,
        MT_TSKELBW,
        MT_RSKELBW,
        MT_XSKELBW,
        MT_WSKELSD,
        MT_TSKELSD,
        MT_RSKELSD,
        MT_XSKELSD,
        MT_INVILORD,
        MT_SNEAK,
        MT_STALKER,
        MT_UNSEEN,
        MT_ILLWEAV,
        MT_LRDSAYTR,
        MT_NGOATMC,
        MT_BGOATMC,
        MT_RGOATMC,
        MT_GGOATMC,
        MT_FIEND,
        MT_BLINK,
        MT_GLOOM,
        MT_FAMILIAR,
        MT_NGOATBW,
        MT_BGOATBW,
        MT_RGOATBW,
        MT_GGOATBW,
        MT_NACID,
        MT_RACID,
        MT_BACID,
        MT_XACID,
        MT_SKING,
        MT_CLEAVER,
        MT_FAT,
        MT_MUDMAN,
        MT_TOAD,
        MT_FLAYED,
        MT_WYRM,
        MT_CAVSLUG,
        MT_DVLWYRM,
        MT_DEVOUR,
        MT_NMAGMA,
        MT_YMAGMA,
        MT_BMAGMA,
        MT_WMAGMA,
        MT_HORNED,
        MT_MUDRUN,
        MT_FROSTC,
        MT_OBLORD,
        MT_BONEDMN,
        MT_REDDTH,
        MT_LTCHDMN,
        MT_UDEDBLRG,
        MT_INCIN,
        MT_FLAMLRD,
        MT_DOOMFIRE,
        MT_HELLBURN,
        MT_STORM,
        MT_RSTORM,
        MT_STORML,
        MT_MAEL,
        MT_BIGFALL,
        MT_WINGED,
        MT_GARGOYLE,
        MT_BLOODCLW,
        MT_DEATHW,
        MT_MEGA,
        MT_GUARD,
        MT_VTEXLRD,
        MT_BALROG,
        MT_NSNAKE,
        MT_RSNAKE,
        MT_BSNAKE,
        MT_GSNAKE,
        MT_NBLACK,
        MT_RTBLACK,
        MT_BTBLACK,
        MT_RBLACK,
        MT_UNRAV,
        MT_HOLOWONE,
        MT_PAINMSTR,
        MT_REALWEAV,
        MT_SUCCUBUS,
        MT_SNOWWICH,
        MT_HLSPWN,
        MT_SOLBRNR,
        MT_COUNSLR,
        MT_MAGISTR,
        MT_CABALIST,
        MT_ADVOCATE,
        MT_GOLEM,
        MT_DIABLO,
        MT_DARKMAGE,
        MT_HELLBOAR,
        MT_STINGER,
        MT_PSYCHORB,
        MT_ARACHNON,
        MT_FELLTWIN,
        MT_HORKSPWN,
        MT_VENMTAIL,
        MT_NECRMORB,
        MT_SPIDLORD,
        MT_LASHWORM,
        MT_TORCHANT,
        MT_HORKDMN,
        MT_DEFILER,
        MT_GRAVEDIG,
        MT_TOMBRAT,
        MT_FIREBAT,
        MT_SKLWING,
        MT_LICH,
        MT_CRYPTDMN,
        MT_HELLBAT,
        MT_BONEDEMN,
        MT_ARCHLICH,
        MT_BICLOPS,
        MT_FLESTHNG,
        MT_REAPER,
        MT_NAKRUL,
        NUM_MTYPES,
        MT_INVALID = -1,
    };

    public enum MonsterAvailability
    {
        Never,
        Always,
        Retail,
    };

    public enum _mai_id 
    {
        AI_ZOMBIE,
        AI_FAT,
        AI_SKELSD,
        AI_SKELBOW,
        AI_SCAV,
        AI_RHINO,
        AI_GOATMC,
        AI_GOATBOW,
        AI_FALLEN,
        AI_MAGMA,
        AI_SKELKING,
        AI_BAT,
        AI_GARG,
        AI_CLEAVER,
        AI_SUCC,
        AI_SNEAK,
        AI_STORM,
        AI_FIREMAN,
        AI_GARBUD,
        AI_ACID,
        AI_ACIDUNIQ,
        AI_GOLUM,
        AI_ZHAR,
        AI_SNOTSPIL,
        AI_SNAKE,
        AI_COUNSLR,
        AI_MEGA,
        AI_DIABLO,
        AI_LAZARUS,
        AI_LAZHELP,
        AI_LACHDAN,
        AI_WARLORD,
        AI_FIREBAT,
        AI_TORCHANT,
        AI_HORKDMN,
        AI_LICH,
        AI_ARCHLICH,
        AI_PSYCHORB,
        AI_NECROMORB,
        AI_BONEDEMON,
        AI_INVALID = -1,
    };

    public enum MonsterClass 
    {
        Undead,
        Demon,
        Animal,
    };

    public enum ItemSpecialEffectHf 
    {
        // clang-format off
        None               = 0,
        Devastation        = 1 << 0,
        Decay              = 1 << 1,
        Peril              = 1 << 2,
        Jesters            = 1 << 3,
        Doppelganger       = 1 << 4,
        ACAgainstDemons    = 1 << 5,
        ACAgainstUndead    = 1 << 6,
        // clang-format on
    };

    public enum MonsterMode 
    {
        Stand,
        /** Movement towards N, NW, or NE */
        MoveNorthwards,
        /** Movement towards S, SW, or SE */
        MoveSouthwards,
        /** Movement towards W or E */
        MoveSideways,
        MeleeAttack,
        HitRecovery,
        Death,
        SpecialMeleeAttack,
        FadeIn,
        FadeOut,
        RangedAttack,
        SpecialStand,
        SpecialRangedAttack,
        Delay,
        Charge,
        Petrified, // 石化
        Heal,
        Talk,
    };

    public enum HeroClass
    {
        Warrior,
        Rogue,
        Sorcerer,
        Monk,
        Bard,
        Barbarian,

        LAST = Barbarian
    };

    [Flags]
    public enum ItemSpecialEffect
    {
        // clang-format off
        None                   = 0,
        RandomStealLife        = 1 << 1,
        RandomArrowVelocity    = 1 << 2,
        FireArrows             = 1 << 3,
        FireDamage             = 1 << 4,
        LightningDamage        = 1 << 5,
        DrainLife              = 1 << 6,
        MultipleArrows         = 1 << 9,
        Knockback              = 1 << 11,
        StealMana3             = 1 << 13,
        StealMana5             = 1 << 14,
        StealLife3             = 1 << 15,
        StealLife5             = 1 << 16,
        QuickAttack            = 1 << 17,
        FastAttack             = 1 << 18,
        FasterAttack           = 1 << 19,
        FastestAttack          = 1 << 20,
        FastHitRecovery        = 1 << 21,
        FasterHitRecovery      = 1 << 22,
        FastestHitRecovery     = 1 << 23,
        FastBlock              = 1 << 24,
        LightningArrows        = 1 << 25,
        Thorns                 = 1 << 26,
        NoMana                 = 1 << 27,
        HalfTrapDamage         = 1 << 28,
        TripleDemonDamage      = 1 << 30,
        ZeroResistance         = 1 << 31,
        // clang-format on
    };

    public enum ItemType
    {
        Misc,
        Sword,
        Axe,
        Bow,
        Mace,
        Shield,
        LightArmor,
        Helm,
        MediumArmor,
        HeavyArmor,
        Staff,
        Gold,
        Ring,
        Amulet,
        None = -1,
    };

    // Logical equipment locations
    public enum inv_body_loc 
    {
        INVLOC_HEAD,
        INVLOC_RING_LEFT,
        INVLOC_RING_RIGHT,
        INVLOC_AMULET,
        INVLOC_HAND_LEFT,
        INVLOC_HAND_RIGHT,
        INVLOC_CHEST,
        NUM_INVLOC,
    };
}
