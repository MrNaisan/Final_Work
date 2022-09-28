using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float StartTimeBtwAttack;
    public Transform AttackPos;
    public LayerMask Enemy;
    public float AttackRange;
    public Animator Anim;
    public SpriteRenderer playerSprite;

    private void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if(Input.GetMouseButton(0) && Input.GetKey(KeyCode.Q))
            {
                PlayerCont.Player.State.AttackType = 1;
                if (!playerSprite.flipX)
                    Anim.SetTrigger("UpAttack");
                else
                    Anim.SetTrigger("UpAttackFlip");
                timeBtwAttack = StartTimeBtwAttack;
            }
            else if(Input.GetMouseButton(0) && Input.GetKey(KeyCode.E))
            {
                PlayerCont.Player.State.AttackType = 2;
                if (!playerSprite.flipX)
                    Anim.SetTrigger("DownAttack");
                else
                    Anim.SetTrigger("DownAttackFlip");
                timeBtwAttack = StartTimeBtwAttack;
            }
            else if(Input.GetMouseButton(0))
            {
                PlayerCont.Player.State.AttackType = 3;
                if (!playerSprite.flipX)
                    Anim.SetTrigger("MidAttack");
                else
                    Anim.SetTrigger("MidAttackFlip");
                timeBtwAttack = StartTimeBtwAttack;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, Enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyLogic>().BLock();
        }
        PlayerCont.Player.State.AttackType = 0;
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange);
    }
}
