using UnityEngine;

namespace DBSkillSystem.Implement
{
    public class DamageBuff : BaseBuff
    {
        private GameObject go;

        public override int Duration => 1000;

        public override void OnBuffCreate()
        {
            base.OnBuffCreate();

            Debug.LogError("创建一个伤害BUFF");
            BuffLayer = 1;
            var goAsset = Resources.Load<GameObject>("Cube");
            go = Object.Instantiate(goAsset);
            go.transform.position = Vector3.zero;

            this.AddDamage();
        }

        public override void OnBuffDestroy()
        {
            base.OnBuffDestroy();
            Debug.LogError("移除一个伤害BUFF");
            Object.DestroyImmediate(go);
        }

#if UNITY_EDITOR
        public override string ToString()
        {
            return $"伤害Buff_{BuffLayer}";
        }
#endif
    }
}