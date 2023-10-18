using Leopotam.Ecs;
using UnityEngine;
using ScriptableObjects;
using Systems.Player;
using System.UI.Joystick;
using Systems.UI.Joystick;

sealed class EcsStartup : MonoBehaviour
{
    [SerializeField] private PlayerInitData _playerInitData;
    [SerializeField] private JoysticUIInitData _joystickUIInitData;
    [SerializeField] private CanvasUIInitData _canvasUIInitData;


        EcsWorld _world;
        EcsSystems _systems;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())
                .Add(new PlayerInitSystem())
                .Add(new PlayerMovementRunSystem())
                .Add(new PlayerAnimationRunSystem())
                .Add(new CanvasUIInitSystem())
                .Add(new JoystickUIInitSystem())
                .Add(new JoystickUIRunSystem())
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                
                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Inject(_playerInitData)
                .Inject(_joystickUIInitData)
                .Inject(_canvasUIInitData)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
}
