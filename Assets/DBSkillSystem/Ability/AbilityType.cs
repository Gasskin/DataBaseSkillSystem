using System;

namespace DBSkillSystem
{
    [Flags]
    public enum AbilityType
    {
        // 被动技能
        PassiveAbility = 1 << 0,

        // 主动技能
        ActiveAbility = 1 << 1,

        // 开关技能
        ToggleAbility = 1 << 2,
    }
}