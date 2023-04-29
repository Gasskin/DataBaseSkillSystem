namespace DBSkillSystem
{
    public class AttackAbility : BaseAbility
    {
        public override void OnSpellStart()
        {
            this.AddDamage();
        }
    }
}