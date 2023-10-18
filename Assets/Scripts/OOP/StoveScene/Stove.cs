using UnityEngine;

namespace OOP.StoveScene
{
    public class Stove : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer mask;
        
        public void SetAlphaObj(float alpha)
        {
            mask.color = new Color(1, 1, 1, alpha);
        }
    }
}
