using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Enemy(float hp, float st, float dm)
    {
        Hp = hp;
        Stamina = st;
        Damage = dm;
    }
}
