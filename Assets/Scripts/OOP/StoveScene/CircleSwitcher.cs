using UnityEngine;

namespace OOP.StoveScene
{
    public class CircleSwitcher : Switcher
    {
        [SerializeField] private Transform switcher;
        [SerializeField] private float greenZoneAngleMin, greenZoneAngleMax, redZoneAngleMin, redZoneAngleMax;
        [SerializeField] private bool switchPressed;

        private Stove _stove;

        private void Start()
        {
            _stove = FindObjectOfType<Stove>();

            switchPressed = false;
        }

        private void Update()
        {
            if (!switchPressed)
                switcher.Rotate(0, 0, -200 * Time.deltaTime);
        }

        //public override void PressedSwitch()
        //{
        //    if (switchPressed)
        //        return;
//
        //    switchPressed = true;
//
        //    Debug.Log(switcher.localEulerAngles.z);
//
        //    if (switcher.localEulerAngles.z > redZoneAngleMin && switcher.localEulerAngles.z < redZoneAngleMax)
        //    {
        //        if (switcher.localEulerAngles.z > greenZoneAngleMin && switcher.localEulerAngles.z < greenZoneAngleMax)
        //        {
        //            Debug.Log("Green Zone");
        //            _stove.AddLightningToStove(100);
        //        }
//
        //        else
        //        {
        //            Debug.Log("Red Zone");
        //            _stove.AddLightningToStove(10);
        //        }
        //    }
//
        //    else
        //    {
        //        Debug.Log("Miss");
        //        _stove.RemoveLightningFromStove();
        //    }
        //}

    }
}
