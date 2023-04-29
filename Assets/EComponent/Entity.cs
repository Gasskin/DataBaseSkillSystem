using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EComponent
{
    public abstract partial class Entity
    {
        // ID
        public long Id { get; set; }

        // 名称
        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
#if UNITY_EDITOR
                GetComponent<GameObjectComponent>()?.OnNameChanged(name);
#endif
            }
        }

        // 实例ID
        public long InstanceId { get; set; }

        // 是否释放
        public bool IsDispose => InstanceId == 0;

        // 父实体
        private Entity parent;
        public Entity Parent => parent;

        // 孩子实体
        public List<Entity> Children { get; private set; } = new List<Entity>();
        public Dictionary<long, Entity> Id2Children { get; private set; } = new Dictionary<long, Entity>();

        public Dictionary<Type, List<Entity>> Type2Children { get; private set; } =
            new Dictionary<Type, List<Entity>>();

        // 持有的组件
        public Dictionary<Type, Component> Components { get; private set; } = new Dictionary<Type, Component>();


        public Entity()
        {
#if UNITY_EDITOR
            if (this is MasterEntity)
                return;
            AddComponent<GameObjectComponent>();
#endif
        }

        public virtual void Awake()
        {
        }

        public virtual void Awake(object initData)
        {
        }

        public virtual void Update()
        {
        }

        public virtual void OnDestroy()
        {
        }

        private void Dispose()
        {
            if (Children.Count > 0)
            {
                for (int i = Children.Count - 1; i >= 0; i--)
                {
                    Destroy(Children[i]);
                }

                Children.Clear();
                Type2Children.Clear();
            }

            Parent?.RemoveChild(this);
            foreach (var component in Components.Values)
            {
                component.Enable = false;
                Component.Destroy(component);
            }

            Components.Clear();
            InstanceId = 0;
            if (MasterEntity.Entities.ContainsKey(GetType()))
            {
                MasterEntity.Entities[GetType()].Remove(this);
            }
        }
        
        public T AddComponent<T>() where T : Component
        {
            var component = Activator.CreateInstance<T>();
            component.Entity = this;
            component.IsDisposed = false;
            Components.Add(typeof(T), component);
            MasterEntity.AllComponents.Add(component);
            component.Awake();
            component.Enable = component.DefaultEnable;

#if UNITY_EDITOR
            GetComponent<GameObjectComponent>()?.OnAddComponent(component);
#endif
            return component;
        }

        public T AddComponent<T>(object initData) where T : Component
        {
            var component = Activator.CreateInstance<T>();
            component.Entity = this;
            component.IsDisposed = false;
            Components.Add(typeof(T), component);
            MasterEntity.AllComponents.Add(component);
            component.Awake(initData);
            component.Enable = component.DefaultEnable;
#if UNITY_EDITOR
            GetComponent<GameObjectComponent>()?.OnAddComponent(component);
#endif
            return component;
        }

        public void RemoveComponent<T>() where T : Component
        {
            var component = Components[typeof(T)];
            if (component.Enable) component.Enable = false;
            Component.Destroy(component);
            Components.Remove(typeof(T));
            
#if UNITY_EDITOR
            GetComponent<GameObjectComponent>()?.OnRemoveComponent(component);
#endif
        }

        public T GetComponent<T>() where T : Component
        {
            if (Components.TryGetValue(typeof(T), out var component))
            {
                return component as T;
            }

            return null;
        }

        public bool HasComponent<T>() where T : Component
        {
            return Components.TryGetValue(typeof(T), out var component);
        }

        public T GetParent<T>() where T : Entity
        {
            return parent as T;
        }

        public T As<T>() where T : class
        {
            return this as T;
        }


        public void RemoveChild(Entity child)
        {
            Children.Remove(child);
            Id2Children.Remove(child.Id);
            if (Type2Children.ContainsKey(child.GetType())) 
                Type2Children[child.GetType()].Remove(child);
        }
        

        public T AddChild<T>() where T : Entity
        {
            var entity = NewEntity(typeof(T));
            SetupEntity(entity, this);
            return entity as T;
        }
        
        public T AddChild<T>(object initData) where T : Entity
        {
            var entity = NewEntity(typeof(T));
            SetupEntity(entity, this, initData);
            return entity as T;
        }


        public T GetChild<T>(int index = 0) where T : Entity
        {
            if (Type2Children.ContainsKey(typeof(T)) == false)
            {
                return null;
            }

            if (Type2Children[typeof(T)].Count <= index)
            {
                return null;
            }

            return Type2Children[typeof(T)][index] as T;
        }

        public Entity[] GetChildren()
        {
            return Children.ToArray();
        }

        public T[] GetTypeChildren<T>() where T : Entity
        {
            return Type2Children[typeof(T)].ConvertAll(x => x.As<T>()).ToArray();
        }

        public Entity Find(string name)
        {
            foreach (var item in Children)
            {
                if (item.name == name) return item;
            }

            return null;
        }

        public T Find<T>(string name) where T : Entity
        {
            if (Type2Children.TryGetValue(typeof(T), out var chidren))
            {
                foreach (var item in chidren)
                {
                    if (item.name == name) return item as T;
                }
            }

            return null;
        }
    }
}