using EComponent;

namespace DBSkillSystem
{
    [DrawProperty]
    public class AttributeComponent : Component
    {
        public float Hp { get; set; }
        public float MaxHp { get; set; }
        public float Mp { get; set; }
        public float MaxMp { get; set; }
        public float Attack { get; set; }
        public float MoveSpeed { get; set; }

        public override void Awake()
        {
            Hp = 1000;
            MaxHp = 1000;
            Mp = 200;
            MaxMp = 200;
            Attack = 50;
            MoveSpeed = 4;
        }

#if UNITY_EDITOR
        public override string ToString()
        {
            return $"血量 {Hp}/{MaxHp}\n"
                   + $"蓝量 {Mp}/{MaxMp}\n"
                   + $"攻击 {Attack}\n"
                   + $"速度 {MoveSpeed}";
        }
#endif
    }
}