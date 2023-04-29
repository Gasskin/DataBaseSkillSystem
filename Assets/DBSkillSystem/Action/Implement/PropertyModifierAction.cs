using System;
using EComponent;

namespace DBSkillSystem
{
    [Flags]
    public enum PropertyModifier
    {
        // 当前生命值
        HP = 1 << 0,

        // 最大生命值
        MAX_HP = 1 << 2,

        // 当前法力值
        MP = 1 << 3,

        // 最大法力值
        MAX_MP = 1 << 4,

        // 攻击力
        ATTACK = 1 << 5,

        // 移动速度
        SPEED = 1 << 6,
    }

    public class PropertyModifierAction : Entity
    {
        public PropertyModifierActionExecution MakeAction()
        {
            return new PropertyModifierActionExecution()
            {
                Creator = Parent.As<CombatEntity>(),
            };
        }
    }


    public class PropertyModifierActionExecution : BaseActionExecution
    {
        public PropertyModifier PropertyModifier { get; set; }

        public float Value { get; set; }

        public void ApplyPropertyModifier()
        {
            if (PropertyModifier.HasFlag(PropertyModifier.SPEED))
            {
                Target.AttributeComponent.MoveSpeed += Value;
            }
        }
    }

    public static partial class ActionEx
    {
        public static void PropertyModifier(this BaseBuff baseBuff, PropertyModifier modifier, float value)
        {
            var action = baseBuff.Owner?.PropertyModifierAction.MakeAction();
            if (action == null)
                return;
            action.Target = baseBuff.Owner;
            action.PropertyModifier = modifier;
            action.Value = value;
            action.ApplyPropertyModifier();
        }
    }
}