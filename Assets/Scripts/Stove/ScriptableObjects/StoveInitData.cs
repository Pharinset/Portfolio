using UnityEngine;

namespace Stove.ScriptableObjects
{
    [CreateAssetMenu(fileName = "StoveInitData", menuName = "ScriptableObjects/Stove/StoveInitData", order = 0)]
    public class StoveInitData : ScriptableObject
    {
        [SerializeField] private float _greenZoneMin;
        [SerializeField] private float _greenZoneMax;
        [SerializeField] private float _redZoneMin;
        [SerializeField] private float _redZoneMax;
        [SerializeField] private GameObject _stoveObj;
        [SerializeField] private GameObject _temperatureObj;
        [SerializeField] private GameObject _temperatureSwitchObj;

        public float GreenZoneMin => _greenZoneMin;
        public float GreenZoneMax => _greenZoneMax;
        public float RedZoneMin => _redZoneMin;
        public float RedZoneMax => _redZoneMax;
        public GameObject StoveObj => _stoveObj;
        public GameObject TemperatureObj => _temperatureObj;
        public GameObject TemperatureSwitchObj => _temperatureSwitchObj;
    }
}
