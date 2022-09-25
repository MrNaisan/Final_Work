using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    private float hp;
    private float stamina;
    private float damage;
    private int attackType;
    private int blockType;
    private float speed;

    public float Hp
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

    public float Stamina
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

    public float Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    public int AttackType
    {
        get
        {
            return attackType;
        }

        set
        {
            attackType = value;
        }
    }

    public int BlockType
    {
        get
        {
            return blockType;
        }

        set
        {
            blockType = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

}
