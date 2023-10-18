using UnityEngine;
using Leopotam.Ecs;
using ScriptableObjects;
using Components.UI.Canvas;
using Components.UI.Joystick;

namespace Systems.UI.Joystick
{
    public class JoystickUIInitSystem : IEcsInitSystem
    {
        readonly EcsWorld _world = null;
        EcsFilter<CanvasUIComponent> _filter;

        private JoysticUIInitData _joysticUIInitData;
        public void Init()
        {
            foreach (var i in _filter)
            {
                var canvasUIComponent = _filter.Get1(i);
                var joystickUI = _world.NewEntity();

                var spawnedJoystick = 
                    GameObject.Instantiate(_joysticUIInitData.JoystickUIRef.gameObject, canvasUIComponent.Root);

                ref var joystickUIComponent = ref joystickUI.Get<JoystickUIComponent>();
                        joystickUIComponent.Header = spawnedJoystick.GetComponent<JoystickUIRef>().JoystickHeader;
                        joystickUIComponent.Body = spawnedJoystick.GetComponent<JoystickUIRef>().JoystickBody;
                        joystickUIComponent.OriginHeaderPosition = 
                                            spawnedJoystick.GetComponent<JoystickUIRef>().JoystickHeader.position;
                        joystickUIComponent.OriginBodyPosition =
                                            spawnedJoystick.GetComponent<JoystickUIRef>().JoystickBody.position;
            }
        }
    }
}
