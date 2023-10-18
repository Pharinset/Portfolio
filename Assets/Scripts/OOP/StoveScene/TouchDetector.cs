using UnityEngine;

namespace OOP.StoveScene
{
    public class TouchDetector : MonoBehaviour
    {
        private void Update()
        {
            if (Input.touchCount > 0)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint
                    (Input.GetTouch(0).position), Vector3.forward);

                if (hit.collider)
                {
                    if (hit.collider.TryGetComponent(out Switcher switcher))
                    {
                        switcher.PressedSwitch();
                    }
                }
            }
        }

    }
}
