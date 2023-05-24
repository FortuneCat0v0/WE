using UnityEngine;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class PlayerToHallInteractionComponent: Entity,IAwake<GameObject>,IDestroy
    {
        public Collider other;
    }
}