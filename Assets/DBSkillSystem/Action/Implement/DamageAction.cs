namespace DBSkillSystem
{
    public class DamageAction
    {
        public void Damage()
        {
            
        }
    }
    
    public static partial class ActionEx
    {
        public static DamageAction AddDamage(this BaseAbility ability)
        {
            return new DamageAction();
        }
        
        public static DamageAction AddDamage(this BaseBuff baseBuff)
        {
            return new DamageAction();
        }
    }
}