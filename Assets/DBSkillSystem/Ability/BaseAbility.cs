using EComponent;

namespace DBSkillSystem
{
    public abstract class BaseAbility : Entity
    {
        // 释放者
        public CombatEntity Creator { get; set; }
        // 释放目标
        public CombatEntity Target { get; set; }
        
        // 前摇，毫秒
        public virtual int WaitBeforeSpell { get; } = 0;
        // 后摇，毫秒
        public virtual int WaitAfterSpell { get; } = 0;
        
        /// <summary>
        /// 持续施法结束
        /// </summary>
        public virtual void OnChannelFinish()
        {
            
        }
        
        /// <summary>
        /// 持续施法中断
        /// </summary>
        public virtual void OnChannelInterrupted()
        {
            
        }

        /// <summary>
        /// 持续施法成功
        /// </summary>
        public virtual void OnChannelSucceeded()
        {
            
        }

        /// <summary>
        /// 持有者死亡
        /// </summary>
        public virtual void OnOwnerDied()
        {
            
        }
        
        /// <summary>
        /// 持有者出生
        /// </summary>
        public virtual void OnOwnerSpawned()
        {
            
        }
       
        /// <summary>
        /// 子弹命中
        /// </summary>
        public virtual void OnProjectileHit()
        {
            
        }
        
        /// <summary>
        /// 子弹结束
        /// </summary>
        public virtual void OnProjectileFinish()
        {
            
        }
        
        /// <summary>
        /// 开始释放
        /// </summary>
        public virtual void OnSpellStart()
        {
            
        }
        
        /// <summary>
        /// 开关打开
        /// </summary>
        public virtual void OnToggleOn()
        {
            
        }
        
        /// <summary>
        /// 开关关闭
        /// </summary>
        public virtual void OnToggleOff()
        {
            
        }
        
        /// <summary>
        /// 升级
        /// </summary>
        public virtual void OnUpgrade()
        {
            
        }
    }
}