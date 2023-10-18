using Leopotam.Ecs;
using Stove.ScriptableObjects;
using Stove.Systems;
using UnityEngine;

namespace Client {
    sealed class EcsStartupStove : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;
        [SerializeField] private StoveInitData _initData;
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
                .Add(new StoveInitSystem())
                .Add(new TemperatureRegulatorInitSystem())
                .Add(new CircleTargetInitSystem())
                .Add(new RotatorSystem())
                .Add(new TouchInputSystem())
                .Add(new CircleTargetSuccessSystem())
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                
                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Inject(_initData)
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
}