using System.Collections.Generic;
using EComponent;

namespace DBSkillSystem
{
    [DrawProperty]
    public class BuffComponent : Component
    {
        private readonly Dictionary<int, BaseBuff> buffDic = new();

        public override void Update()
        {
            foreach (var buff in buffDic.Values)
            {
                buff.BuffTimer.Update();
            }
        }

        public void AddBuff(BaseBuff baseBuff)
        {
            buffDic[baseBuff.BuffId] = baseBuff;
        }

        public bool TryGetBuff(BaseBuff baseBuff, out BaseBuff buff)
        {
            buff = null;
            if (buffDic.TryGetValue(baseBuff.BuffId, out buff))
            {
                return true;
            }
            return false;
        }

#if UNITY_EDITOR
        public override string ToString()
        {
            var first = true;
            var str = "";
            foreach (var buff in buffDic.Values)
            {
                str += (first ? $"{buff}" : $"\n{buff}");
                first = false;
            }

            return str;
        }
#endif
    }
}