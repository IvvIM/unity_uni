using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Potion : Item
{
    enum PotionName
    {
        //enum з назвами ефектів
    }

    protected void ApplyEffectToPlayer()
    {
        //Застосовує ефект на гравця
    }
}
