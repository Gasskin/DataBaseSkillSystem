using System;
using DBSkillSystem;
using DBSkillSystem.Implement;
using EComponent;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    private CombatEntity Hero;

    private void Awake()
    {
        Hero = MasterEntity.Instance.AddChild<CombatEntity>();
        Hero.GameObject = gameObject;
        
        var action = Hero.AddBuffAction.MakeAction();
        action.Buff = new DamageBuff();
        action.AddBuff();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var action = Hero.AddBuffAction.MakeAction();
            action.Target = Hero;
            action.Buff = new SpeedBuff
            {
                value = 50,
                Duration = 6000,
            };
            action.AddBuff();
        }
    }
}
