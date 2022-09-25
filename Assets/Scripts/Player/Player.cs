using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private State state;
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
    public void Awake() 
    {
        PlayerCont.Player = this;
        state = new State();
        State.Hp = 10;
        State.Damage = 1;
        State.Stamina = 10;
        State.Speed = 5;
    }
    
}
