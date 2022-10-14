using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAnim : MonoBehaviour
{
   public EnemyLogic Logic;
   public Animator Anim;

    private void Update() 
    {
        if (Logic.isDeteced)
            Anim.SetBool("IsMove", true);
        else
            Anim.SetBool("IsMove", false);
    }
}
