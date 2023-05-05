using System.Collections.Generic;
using EComponent;
using UnityEngine;

namespace DBSkillSystem
{
    public class CombatEntity : Entity
    {
        public GameObject GameObject { get; set; }
        
        public AddBuffAction AddBuffAction { get; set; }
        public PropertyModifierAction PropertyModifierAction { get; set; }
        
        
        public MoveComponent MoveComponent { get; set; }
        public ActionPointComponent ActionPointComponent { get; set; }
        public BuffComponent BuffComponent { get; set; }
        public AttributeComponent AttributeComponent { get; set; }
        public SpellAbilityAction SpellAbilityAction { get; set; }
        
        public override void Awake()
        {
            AddBuffAction = AddChild<AddBuffAction>();
            PropertyModifierAction = AddChild<PropertyModifierAction>();
            SpellAbilityAction = AddChild<SpellAbilityAction>();
            
            MoveComponent = AddComponent<MoveComponent>();
            ActionPointComponent = AddComponent<ActionPointComponent>();
            BuffComponent = AddComponent<BuffComponent>();
            AttributeComponent = AddComponent<AttributeComponent>();
        }
    }
}