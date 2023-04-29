using UnityEngine;

namespace DBSkillSystem.Implement
{
    public class DamageBuff : BaseBuff
    {
        public override void OnBuffCreate()
        {
            Debug.LogError("创建一个伤害BUFF");
            BuffLayer = 1;
            var go = Resources.Load<GameObject>("Cube");
            var trans = Object.Instantiate(go).transform;
            trans.position = Vector3.zero;

            this.AddDamage();
        }

        public override void OnBuffDestroy()
        {
            BuffLayer--;
            Debug.LogError("移除一个伤害BUFF");
        }

#if UNITY_EDITOR
        public override string ToString()
        {
            return $"伤害Buff_{BuffLayer}";
        }
#endif
    }
}