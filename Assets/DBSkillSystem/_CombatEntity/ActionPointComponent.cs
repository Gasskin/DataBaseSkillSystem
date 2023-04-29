using System;
using System.Collections.Generic;
using EComponent;

namespace DBSkillSystem
{
    [Flags]
    public enum ActionPoint
    {
        // 施法前，针对非持续施法技能
        BEFORE_SPELL_ABILITY = 1 << 0,
        // 施法后，针对非持续施法技能
        AFTER_SPELL_ABILITY = 1 << 1,
        
        // 添加BUFF前
        BEFORE_ADD_BUFF = 1 << 2,
        // 添加BUFF后
        AFTER_ADD_BUFF = 1 << 3,
        // 获得BUFF前
        BEFORE_GET_BUFF = 1 << 4,
        // 获得BUFF后
        AFTER_GET_BUFF = 1 << 5,
        
        // 攻击前
        BEFORE_ATTACK = 1 << 6,
        // 攻击后
        AFTER_ATTACK = 1 << 7,
        // 受到攻击前
        BEFORE_RECEIVE_ATTACK = 1 << 8,
        // 受到攻击后
        AFTER_RECEIVE_ATTACK = 1 << 9,
    }
    
    [DrawProperty]
    public class ActionPointComponent : Component
    {
        private readonly Dictionary<ActionPoint,List<Action<BaseActionExecution>>> actionPointListeners = new();
        
        /// <summary>
        /// 添加行动点监听
        /// </summary>
        /// <param name="actionPoint"></param>
        /// <param name="action"></param>
        public void AddActionPointListener(ActionPoint actionPoint, Action<BaseActionExecution> action)
        {
            if (!actionPointListeners.ContainsKey(actionPoint))
            {
                actionPointListeners.Add(actionPoint,new List<Action<BaseActionExecution>>());
            }
            actionPointListeners[actionPoint].Add(action);
        }

        /// <summary>
        /// 移除行动点监听
        /// </summary>
        /// <param name="actionPoint"></param>
        /// <param name="action"></param>
        public void RemoveActionPointListener(ActionPoint actionPoint, Action<BaseActionExecution> action)
        {
            if (actionPointListeners.TryGetValue(actionPoint,out var list))
            {
                list.Remove(action);
            }
        }
        
        /// <summary>
        /// 触发行动点
        /// </summary>
        /// <param name="actionPoint"></param>
        /// <param name="baseAction"></param>
        public void TriggerActionPoint(ActionPoint actionPoint, BaseActionExecution actionExecution)
        {
            if (actionPointListeners.TryGetValue(actionPoint,out var list))
            {
                foreach (var action in list)
                {
                    action?.Invoke(actionExecution);
                }
            }
        }

#if UNITY_EDITOR
        public override string ToString()
        {
            var first = true;
            var str = "";
            foreach (var pair in actionPointListeners)
            {
                str+= (first ? $"{pair.Key}_{pair.Value.Count}" : $"\n{pair.Key}_{pair.Value.Count}");
                first = false;
            }

            return str;
        }
#endif
    }
}