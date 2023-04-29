namespace EComponent
{
    public class Component
    {
        // 持有该组件的实体
        public Entity Entity { get; set; }
        
        // 是否释放
        public bool IsDisposed { get; set; }
        
        // 默认是否启用
        public virtual bool DefaultEnable { get; set; } = true;
        
        // 是否启用
        private bool enable = false;
        public bool Enable
        {
            get => enable;
            set
            {
                if (enable == value) return;
                enable = value;
                if (enable) OnEnable();
                else OnDisable();
            }
        }
        public bool Disable => enable == false;
        
        public T GetEntity<T>() where T : Entity
        {
            return Entity as T;
        }

        public virtual void Awake()
        {

        }

        public virtual void Awake(object initData)
        {

        }

        public virtual void OnEnable()
        {

        }

        public virtual void OnDisable()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void OnDestroy()
        {
            
        }


        public static void Destroy(Component component)
        {
            component.Enable = false;
            component.OnDestroy();
            component.IsDisposed = true;
        }
    }
}
