using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public static Player instance;
    public void Awake() 
    {
        instance = new Player();
        instance.Hp = 10;
        instance.Damage = 1;
        instance.Stamina = 10;
    }
    
}
