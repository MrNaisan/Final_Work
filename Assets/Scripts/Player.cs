using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private Player() {}
    public static Player instance;
    public static Player getInstans()
    {   
        if(instance == null)
            instance = new Player();
        return instance;
    }
    private int hp = 10;
    private int stamina = 10;
    private int attack = 10;
    private int attackType;
    private int blockType;
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
}
