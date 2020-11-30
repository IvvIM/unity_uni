using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual void ConfirmInteract()
    {
        //Метод який викликається коли гравець починає взаємодіяти з сутністю
        InInteract();
    }

    public virtual void DeclineInteract()
    {
        //Метод який віклікаеться коли гравець припиняє взаємодіяти з сутністю
        OutInteract();
    }

    protected virtual bool PlayerCanInteract()
    {
        //Перевірка чи гравець може взаємодіяти з сутністю
    }

    protected virtual bool IsPlayer()
    {
        //Перевірка на гравця в зоні дій
    }

    protected virtual void OnPlayerEnter()
    {
        //Викликає деякі методи при вході гравця в зону дій
    }

    protected virtual void OnPlayerExit()
    {
        //Викликає деякі методи при виході гравця з зони дій
    }

    protected virtual void InInteract()
    {
        //Вхід в стан взаємодії
    }

    protected virtual void OutInteract()
    {
        //Вихід з стану взаємодії
    }
}

