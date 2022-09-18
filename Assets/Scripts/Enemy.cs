using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    private List<int> availableBlocks;
    private List<int> availableAttacks;
    private bool isAttack;
    private bool isBlock;
    public List<int> AvailableAttacks
    {
        get
        {
            return availableAttacks;
        }
        set
        {
            availableAttacks = value;
        }
    }
    public List<int> AvailableBlocks
    {
        get
        {
            return availableBlocks;
        }
        set
        {
            availableBlocks = value;
        }
    }
    public bool IsAttack
    {
        get
        {
            return isAttack;
        }
        set
        {
            isAttack = value;
        }
    }
    public bool IsBlock
    {
        get
        {
            return isBlock;
        }
        set
        {
            isBlock = value;
        }
    }
    public Enemy(float hp, float st, float dm, List<int> aa, List<int> ab, float sp)
    {
        Hp = hp;
        Stamina = st;
        Damage = dm;
        AvailableAttacks = aa;
        AvailableBlocks = ab;
        Speed = sp;
    }
}
