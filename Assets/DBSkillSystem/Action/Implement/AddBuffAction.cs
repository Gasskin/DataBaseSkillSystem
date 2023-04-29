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
            if (Target == null) 
                return;

            Buff.Creator = Creator;
            Buff.Owner = Target;
            
            Creator?.ActionPointComponent?.TriggerActionPoint(ActionPoint.BEFORE_ADD_BUFF, this);
            Target?.ActionPointComponent?.TriggerActionPoint(ActionPoint.BEFORE_GET_BUFF, this);

            if (!Continue)
            {
                Buff.OnBuffDestroy();
                return;
            }

            if (Target.BuffComponent.TryGetBuff(Buff,out var buff))
            {
                if (buff.CanStack)
                    buff.OnBuffRefresh();
                else
                    buff.OnReset();
            }
            else
            {
                Target.BuffComponent.AddBuff(Buff);
                Buff.OnBuffCreate();
            }            
            
            Creator?.ActionPointComponent?.TriggerActionPoint(ActionPoint.AFTER_ADD_BUFF, this);
            Target?.ActionPointComponent?.TriggerActionPoint(ActionPoint.AFTER_GET_BUFF, this);
        }
    }
}