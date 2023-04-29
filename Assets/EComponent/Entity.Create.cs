using System;
using System.Collections.Generic;

namespace EComponent
{
    public abstract partial class Entity
    {
        public static MasterEntity MasterEntity => EComponent.MasterEntity.Instance;

        public static Entity NewEntity(Type entityType, long id = 0)
        {
            var entity = Activator.CreateInstance(entityType) as Entity;
            entity.InstanceId = IdFactory.NewInstanceId();
            if (id == 0) entity.Id = entity.InstanceId;
            else entity.Id = id;
            if (!MasterEntity.Entities.ContainsKey(entityType))
            {
                MasterEntity.Entities.Add(entityType, new List<Entity>());
            }
            MasterEntity.Entities[entityType].Add(entity);
            return entity;
        }

        public static T Create<T>() where T : Entity
        {
            var entity = NewEntity(typeof(T));
            SetupEntity(entity, MasterEntity);
            return entity as T;
        }

        public static T Create<T>(object initData) where T : Entity
        {
            var entity = NewEntity(typeof(T));
            SetupEntity(entity, MasterEntity, initData);
            return entity as T;
        }
        
        public static void Destroy(Entity entity)
        {
            entity.OnDestroy();
            entity.Dispose();
        }

        private static void SetupEntity(Entity entity, Entity parent)
        {
            parent.SetChild(entity);
            {
                entity.Awake();
            }
        }

        private static void SetupEntity(Entity entity, Entity parent, object initData)
        {
            parent.SetChild(entity);
            {
                entity.Awake(initData);
            }
        }
        
        private void SetChild(Entity child)
        {
            Children.Add(child);
            Id2Children.Add(child.Id, child);
            if (!Type2Children.ContainsKey(child.GetType())) 
                Type2Children.Add(child.GetType(), new List<Entity>());
            Type2Children[child.GetType()].Add(child);
            child.SetParent(this);
        }
        
        private void SetParent(Entity parent)
        {
            var preParent = Parent;
            preParent?.RemoveChild(this);
            this.parent = parent;
#if UNITY_EDITOR
            parent.GetComponent<GameObjectComponent>()?.OnAddChild(this);
#endif
        }
    }
}