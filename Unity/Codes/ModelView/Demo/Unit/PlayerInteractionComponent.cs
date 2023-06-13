using UnityEngine;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class PlayerInteractionComponent: Entity,IAwake<GameObject>,IDestroy
    {
        public Collider other;
    }
}