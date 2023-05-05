using EComponent;
using UnityEngine;
using Component = EComponent.Component;

namespace DBSkillSystem
{
    public class MoveComponent : Component
    {
        public override bool DefaultEnable { get; set; } = true;

        private CombatEntity Owner => Entity.As<CombatEntity>();
        private AttributeComponent AttributeComponent => Owner.AttributeComponent;

        public override void Update()
        {
            if (!Enable)
                return;

            // 横向输入
            var horizontal = Input.GetAxis("Horizontal");
            // 纵向输入
            var vertical = Input.GetAxis("Vertical");

            // 对于Gameobject来说，Z轴是前方（纵向
            var pos = Owner.GameObject.transform.position;
            var offsetV = pos.z + vertical * AttributeComponent.MoveSpeed * Time.deltaTime;
            var offsetH = pos.x + horizontal * AttributeComponent.MoveSpeed * Time.deltaTime;

            Owner.GameObject.transform.position = new Vector3(offsetH, 1, offsetV);
        }
    }
}