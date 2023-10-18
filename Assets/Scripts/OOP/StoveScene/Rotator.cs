using UnityEngine;

namespace OOP.StoveScene
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private Transform _rotateObj;

        public void Rotate(float angle)
        {
            _rotateObj.transform.Rotate(new Vector3(0, 0, angle));
        }

        public Transform GetRotateObj() => _rotateObj.transform;
    }
}
