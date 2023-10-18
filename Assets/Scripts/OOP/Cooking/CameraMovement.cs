using UnityEngine;

namespace OOP.Cooking
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float scope;

        private Camera _mainCamera;

        private Vector2 _firstTouchPosition;
        private Vector2 _secondTouchPosition;
        private Vector2 _touchDirection;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                    _firstTouchPosition = touch.position;

                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    _secondTouchPosition = touch.position;
                    _touchDirection = _firstTouchPosition - _secondTouchPosition;
                    _touchDirection = Vector2.ClampMagnitude(_touchDirection, 10f);

                    if (Mathf.Abs(_mainCamera.transform.position.x + _touchDirection.x * Time.deltaTime) <= scope)
                                  _mainCamera.transform.position += new Vector3(_touchDirection.x, 0, 0) * Time.deltaTime;

                    Debug.Log(_touchDirection.x);
                }

                if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    _firstTouchPosition = _secondTouchPosition = _touchDirection = Vector2.zero;

                }
               
            }
        }
    }
}
