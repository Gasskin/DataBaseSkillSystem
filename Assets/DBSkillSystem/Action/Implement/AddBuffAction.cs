using EComponent;

namespace DBSkillSystem
{
    public class AddBuffAction : Entity
    {
        public AddBuffActionExecution MakeAction()
        {
            return new AddBuffActionExecution
            {
                Creator = Parent.As<CombatEntity>()
            };
        }
    }

    public class AddBuffActionExecution : BaseActionExecution
    {
        public BaseBuff Buff;
        
        public bool Continue { get; set; } = true;
        
        public void AddBuff()
        {
            if (Buff == null) 
                return;
            if (Targets == null) 
                return;

            Buff.Creator = Creator;
            Buff.Owner = Targets;
            
            Creator?.ActionPointComponent?.TriggerActionPoint(ActionPoint.BEFORE_ADD_BUFF, this);
            Targets?.ActionPointComponent?.TriggerActionPoint(ActionPoint.BEFORE_GET_BUFF, this);

            if (!Continue)
            {
                Buff.OnBuffDestroy();
                return;
            }

            if (Targets.BuffComponent.TryGetBuff(Buff,out var buff))
            {
                if (buff.CanStack)
                    buff.OnBuffRefresh();
                else
                    buff.OnReset();
            }
            else
            {
                Targets.BuffComponent.AddBuff(Buff);
                Buff.OnBuffCreate();
            }            
            
            Creator?.ActionPointComponent?.TriggerActionPoint(ActionPoint.AFTER_ADD_BUFF, this);
            Targets?.ActionPointComponent?.TriggerActionPoint(ActionPoint.AFTER_GET_BUFF, this);
        }
    }
    
    public static partial class ActionEx
    {
        public static void AddBuff(this BaseAbility baseAbility, BaseBuff baseBuff, CombatEntity Target)
        {
            var action = baseAbility.Creator?.AddBuffAction.MakeAction();
            if (action == null) 
                return;
            action.Buff = baseBuff;
            action.Targets = Target;
            action.AddBuff();
        }
    }
}














