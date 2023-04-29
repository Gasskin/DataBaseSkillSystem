using UnityEngine;

namespace EComponent
{
    public class ECEntrance : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Enter()
        {
            var go = new GameObject("Entrance");
            go.AddComponent<ECEntrance>();
            DontDestroyOnLoad(go);
        }

        private void Update()
        {
            MasterEntity.Instance.Update();
        }
    }
}
