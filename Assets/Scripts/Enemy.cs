using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    
    public int UpAttack()
    {
        return Attack;
    }

    public int DownAttack()
    {
        return Attack;
    }

    public int MidAttack()
    {
        return Attack;
    }

    public int UpBlock()
    {
        return Stamina;
    }

    public int DownBlock()
    {
        return Stamina;
    }

    public int MidBlock()
    {
        return Stamina;
    }
}
