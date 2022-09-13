using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    private static int hp = 10;
    private static int stamina = 10;
    private static int attack = 10;
    private static int attackType;
    private static int blockType;
    public static int Hp
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
    public static int Stamina
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
    public static int Attack
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
    public static int AttackType
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
    public static int BlockType
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
}
