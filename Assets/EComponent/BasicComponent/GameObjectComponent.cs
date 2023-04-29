using UnityEngine;

namespace EComponent
{
    public class GameObjectComponent : Component
    {
        public GameObject GameObject { get;private set; }

        public override void Awake()
        {
            GameObject = new GameObject(Entity.GetType().Name);
            GameObject.AddComponent<ComponentView>();
        }
        
        public override void OnDestroy()
        {
            base.OnDestroy();
            UnityEngine.GameObject.Destroy(GameObject);
        }
        
        public void OnNameChanged(string name)
        {
            GameObject.name = $"{Entity.GetType().Name}: {name}";
        }

        public void OnAddComponent(Component component)
        {
            var view = GameObject.GetComponent<ComponentView>();
            view.componts.Add(component);
        }

        public void OnRemoveComponent(Component component)
        {
            var view = GameObject.GetComponent<ComponentView>();
            view.componts.Remove(component);
        }

        public void OnAddChild(Entity child)
        {
            if (child.GetComponent<GameObjectComponent>() != null)
            {
                child.GetComponent<GameObjectComponent>().GameObject.transform.SetParent(GameObject.transform);
            }
        }

        public override string ToString()
        {
            return GameObject.name;
        }
    }
}