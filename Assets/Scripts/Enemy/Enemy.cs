using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    private State state;
    private List<int> availableBlocks;
    private List<int> availableAttacks;
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
    public State State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
        }
    }
    public Enemy(float hp, float st, float dm, List<int> aa, List<int> ab, float sp)
    {
        state = new State();
        State.Hp = hp;
        State.Stamina = st;
        State.Damage = dm;
        AvailableAttacks = aa;
        AvailableBlocks = ab;
        State.Speed = sp;
    }
}
