using System.Collections;
using System.Collections.Generic;
using DBSkillSystem;
using DBSkillSystem.Implement;
using EComponent;
using UnityEngine;

public class Test : MonoBehaviour
{
    private CombatEntity hero;

    private CombatEntity monster;
    
    void Start()
    {
        hero = MasterEntity.Instance.AddChild<CombatEntity>();
        monster = MasterEntity.Instance.AddChild<CombatEntity>();
        
        var action = hero.AddBuffAction.MakeAction();
        action.Target = monster;
        action.Buff = new DamageBuff();
        action.AddBuff();
        
        hero.ActionPointComponent.AddActionPointListener(ActionPoint.AFTER_ADD_BUFF,(execution => {}));
        hero.ActionPointComponent.AddActionPointListener(ActionPoint.AFTER_ADD_BUFF,(execution => {}));
        hero.ActionPointComponent.AddActionPointListener(ActionPoint.BEFORE_ADD_BUFF,(execution => {}));
        hero.ActionPointComponent.AddActionPointListener(ActionPoint.BEFORE_SPELL_ABILITY,(execution => {}));
    }
}
