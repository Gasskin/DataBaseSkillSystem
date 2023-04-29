using System.Collections.Generic;
using EComponent;

namespace DBSkillSystem
{
    public class CombatEntity : Entity
    {
        public AddBuffAction AddBuffAction { get; set; }
        
        public ActionPointComponent ActionPointComponent { get; set; }
        public BuffComponent BuffComponent { get; set; }

        public override void Awake()
        {
            AddBuffAction = AddChild<AddBuffAction>();

            ActionPointComponent = AddComponent<ActionPointComponent>();
            BuffComponent = AddComponent<BuffComponent>();
        }
    }
}