using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : Interactable
{
    public bool CanBeAttacked()
    {
        //Перевірка може NPC бути атакований
    }

    public bool IsDialogue()
    {
        //Перевірка чи має NPC діалог
    }
}
