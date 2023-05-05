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
        Hero.AddAbility<DamageRingAbility>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            var action = Hero.AddBuffAction.MakeAction();
            action.Targets = Hero;
            action.Buff = new SpeedBuff
            {
                value = 50,
                Duration = 0,
            };
            action.AddBuff();
        }
    }
}
