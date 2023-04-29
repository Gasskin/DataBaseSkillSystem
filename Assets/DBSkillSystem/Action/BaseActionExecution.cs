using EComponent;

namespace DBSkillSystem
{
    public abstract class BaseActionExecution
    {
        public CombatEntity Creator { get; set; }
        public CombatEntity Target { get; set; }
    }
}