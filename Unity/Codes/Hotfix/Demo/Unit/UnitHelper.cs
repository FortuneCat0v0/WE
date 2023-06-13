namespace ET
{
    public static class UnitHelper
    {
        public static Unit GetMyUnitFromZoneScene(Scene zoneScene)
        {
            PlayerComponent playerComponent = zoneScene.GetComponent<PlayerComponent>();
            if (null == playerComponent)
            {
                return null;
            }

            return zoneScene?.CurrentScene()?.GetComponent<UnitComponent>()?.Get(playerComponent.MyId);
        }

        public static Unit GetMyUnitFromCurrentScene(Scene currentScene)
        {
            PlayerComponent playerComponent = currentScene?.ZoneScene()?.GetComponent<PlayerComponent>();
            if (null == playerComponent)
            {
                return null;
            }

            return currentScene.GetComponent<UnitComponent>()?.Get(playerComponent.MyId);
        }

        public static NumericComponent GetMyUnitNumericComponent(Scene currentScene)
        {
            PlayerComponent playerComponent = currentScene?.ZoneScene()?.GetComponent<PlayerComponent>();
            if (null == playerComponent)
            {
                return null;
            }

            return currentScene.GetComponent<UnitComponent>()?.Get(playerComponent.MyId)?.GetComponent<NumericComponent>();
        }
    }
}