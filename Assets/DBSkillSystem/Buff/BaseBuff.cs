using EComponent;

namespace DBSkillSystem
{
    public class BaseBuff
    {
        // 创建者
        public CombatEntity Creator { get; set; }

        // 持有者
        public CombatEntity Owner { get; set; }

        // 技能源
        public BaseAbility Ability { get; set; }

        // Buff层数
        public int BuffLayer { get; set; } = 0;


        // Buff持续时间，毫秒
        public virtual int Duration { get; set; } = 0;
        // 间隔时间，毫秒
        public virtual int Interval { get; set; } = 0;
        // BuffId
        public virtual int BuffId { get; } = 0;
        // 可否叠加
        public virtual bool CanStack { get; } = false;

        public GameTimer BuffTimer { get; private set; }


        /// <summary>
        /// 创建时
        /// </summary>
        public virtual void OnBuffCreate()
        {
            if (Duration != 0) 
                BuffTimer = new GameTimer(Duration);
            BuffLayer = 1;
            Owner?.ActionPointComponent?.AddActionPointListener(ActionPoint.BEFORE_ATTACK, OnBeforeAttack);
            Owner?.ActionPointComponent?.AddActionPointListener(ActionPoint.AFTER_ATTACK, OnAfterAttack);
            Owner?.ActionPointComponent?.AddActionPointListener(ActionPoint.BEFORE_RECEIVE_ATTACK, OnBeforeReceiveAttack);
            Owner?.ActionPointComponent?.AddActionPointListener(ActionPoint.AFTER_RECEIVE_ATTACK, OnAfterReceiveAttack);
        }

        /// <summary>
        /// 刷新时
        /// </summary>
        public virtual void OnBuffRefresh()
        {
            BuffLayer += 1;
        }
        
        /// <summary>
        /// 重置时
        /// </summary>
        public virtual void OnReset()
        {
            BuffTimer?.Reset();
        }
        
        /// <summary>
        /// 被移除时
        /// </summary>
        public virtual void OnBuffRemove()
        {
            Owner?.ActionPointComponent?.RemoveActionPointListener(ActionPoint.BEFORE_ATTACK, OnBeforeAttack);
            Owner?.ActionPointComponent?.RemoveActionPointListener(ActionPoint.AFTER_ATTACK, OnAfterAttack);
            Owner?.ActionPointComponent?.RemoveActionPointListener(ActionPoint.BEFORE_RECEIVE_ATTACK, OnBeforeReceiveAttack);
            Owner?.ActionPointComponent?.RemoveActionPointListener(ActionPoint.AFTER_RECEIVE_ATTACK, OnAfterReceiveAttack);
        }

        /// <summary>
        /// 被销毁时
        /// </summary>
        public virtual void OnBuffDestroy()
        {
            
        }
        
        
        /// <summary>
        /// 持有者被攻击前
        /// </summary>
        public virtual void OnBeforeReceiveAttack(BaseActionExecution actionExecution)
        {
            
        }
        
        /// <summary>
        /// 持有者被攻击后
        /// </summary>
        public virtual void OnAfterReceiveAttack(BaseActionExecution actionExecution)
        {
            
        }

        /// <summary>
        /// 持有者攻击后
        /// </summary>
        public virtual void OnAfterAttack(BaseActionExecution actionExecution)
        {
            
        }

        /// <summary>
        /// 持有者开始攻击前
        /// </summary>
        public virtual void OnBeforeAttack(BaseActionExecution actionExecution)
        {
            
        }

        /// <summary>
        /// 持有者造成伤害时
        /// </summary>
        public virtual void OnDealDamage(BaseActionExecution actionExecution)
        {
            
        }

        /// <summary>
        /// 持有者收到伤害时
        /// </summary>
        public virtual void OnTakeDamage(BaseActionExecution actionExecution)
        {
            
        }
        
        /// <summary>
        /// 持有者死亡时
        /// </summary>
        public virtual void OnDeath(BaseActionExecution actionExecution)
        {
            
        }



        /// <summary>
        /// 创造一个子弹时
        /// </summary>
        public virtual void OnCreateOrb(BaseActionExecution actionExecution)
        {
            
        }

        /// <summary>
        /// 释放子弹时
        /// </summary>
        public virtual void OnOrbFire(BaseActionExecution actionExecution)
        {
            
        }
        
        /// <summary>
        /// 当法球命中时
        /// </summary>
        public virtual void OnOrbHit(BaseActionExecution actionExecution)
        {
            
        }

        /// <summary>
        /// 定时器操作，配合Duration和Interval使用
        /// </summary>
        public virtual void OnIntervalTick(BaseActionExecution actionExecution)
        {
            
        }
    }
}