using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Interactable
{
    protected virtual bool PlayerCanInteract()
    {
        //Перевірка чи гравець може взаємодіяти з сутністю (Чи сутність може атакувати гравця) 
    }

    protected virtual void StartFollowPlayer()
    {
        //Початок переслідування гравця
    }

    protected virtual void FollowPlayer()
    {
        //Переслідування гравця
    }

    protected virtual void EndFollowPlayer()
    {
        //Закінчення переслідування гравця
    }

    protected virtual void СanFollowPlayer()
    {
        //Перевірка чи може сутність переслідувати гравця
    }

    protected virtual void OnDeath()
    {
        //Смерть сутності
    }

    protected virtual void LootsSpawn()
    {
        //Поява предметів
    }

    public virtual bool IsFollowPlayer()
    {
        //Перевірка чи cутність переслідуе гравця
    }

}
