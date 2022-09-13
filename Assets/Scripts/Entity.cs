using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity
{
    private int hp;
    private int stamina;
    private int attack;
    public int Hp
    {
        get
        {
            return hp;
        }
        set 
        {
            hp = value;
        }
    }
    public int Stamina
    {
        get
        {
            return stamina;
        }
        set
        {
            stamina = value;
        }
    }
    public int Attack
    {
        get
        {
            return attack;
        }
        set
        {
            attack = value;
        }
    }
}
