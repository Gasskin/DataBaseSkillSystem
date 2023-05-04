using EComponent;

namespace DBSkillSystem.Implement
{
    [DrawProperty]
    public class SpeedBuff : BaseBuff
    {
        public override int BuffId => 1;
        public override bool CanStack => true;
        
        public float value = 20;
        
        public override void OnBuffCreate()
        {
            base.OnBuffCreate();
            this.PropertyModifier(PropertyModifier.MAX_HP | PropertyModifier.SPEED, value);
        }

        public override void OnBuffRemove()
        {
            base.OnBuffRemove();
            this.PropertyModifier(PropertyModifier.MAX_HP | PropertyModifier.SPEED, -value);
        }

#if UNITY_EDITOR
        public override string ToString()
        {
            return $"移动速度 {value}_{BuffLayer}";
        }
#endif
    }
}