using DBSkillSystem.Implement;
using UnityEngine;

namespace DBSkillSystem
{
    public class DamageRingAbility : BaseAbility
    {
        public override AbilityType AbilityType => AbilityType.PassiveAbility;

        public override void OnAbilityAdd()
        {
            base.OnAbilityAdd();
            this.AddBuff(new SpeedBuff(),Parent.As<CombatEntity>());
        }

        public override void OnAbilityRemove()
        {
            base.OnAbilityRemove();
        }
    }
}