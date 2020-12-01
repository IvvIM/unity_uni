using UnityEngine;
using UnityEditor;

namespace Assets.Scripts
{
    public class Effect : MonoBehaviour
    {
        public Effect()
        {
            //Обьява назва, сили, час дій(якщо ефект не одноразовий), чи ефект додаеться, дія ефекту
        }

        public bool IsTimedEffect()
        {
            //Перевірка чи одноразовий ефект
        }

        public void StartEffectAction()
        {
            //Початок дій ефекту
        }
    }
}