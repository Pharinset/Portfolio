using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "JoystickUIInitData", menuName = "ScriptableObjects/JoysticUIInitData", order = 0)]
    public class JoysticUIInitData : ScriptableObject
    {
        [SerializeField] private JoystickUIRef _joystickUIRef;

        public JoystickUIRef JoystickUIRef => _joystickUIRef;
        

    }
}
