using EComponent;

namespace DBSkillSystem
{
    public class SpellAbilityAction : Entity
    {
        public SpellAbilityActionExecution MakeAction()
        {
            return new SpellAbilityActionExecution();
        }
    }

    public class SpellAbilityActionExecution : BaseActionExecution
    {
        public BaseAbility Ability;

        public void ApplyAbility()
        {
            
        }
    }
}