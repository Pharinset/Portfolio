using FruitNinja.ScriptableObjects;
using FruitNinja.Systems;
using Leopotam.Ecs;
using UnityEngine;


    sealed class EcsStartupFruitNinja : MonoBehaviour
    {
        [SerializeField] private BladeInitData _bladeInitData;
        [SerializeField] private FruitInitData _fruitInitData;
        [SerializeField] private FruitCannonInitData _fruitCannonInitData;

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
                 .Add(new BladeInitSystem())
                 .Add(new FruitSpawnSystem())
                 .Add(new FruitMovementSystem())
                 .Add(new BladeRunSystem())
                 .Add(new BladeCutSystem())
                 .Add(new FruitSeparatorSystem())
                 // register one-frame components (order is important), for example:
                 // .OneFrame<TestComponent1> ()
                 // .OneFrame<TestComponent2> ()

                 // inject service instances here (order doesn't important), for example:
                 // .Inject (new CameraService ())
                 // .Inject (new NavMeshSupport ())
                .Inject(_bladeInitData)
                .Inject(_fruitInitData)
                .Inject(_fruitCannonInitData)
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
