namespace DBSkillSystem
{
    public class AttackAbility : BaseAbility
    {
        public override AbilityType AbilityType => AbilityType.ActiveAbility;

        public override void OnSpellStart()
        {
            this.AddDamage();
        }
    }
}