using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public virtual bool CanPickUp()
    {
        //Перевірка чи може гравець підняти предмет
    }

    protected virtual void PickedUp()
    {
        // Віконуеться коли гравець підняв предмет
    }
}
