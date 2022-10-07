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
            AttackAnimStart();
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void AttackAnimStart()
    {
        if(Input.GetMouseButton(0) && Input.GetKey(KeyCode.Q))
        {
            OffRegen();
            PlayerCont.Player.State.AttackType = 1;
            if (!playerSprite.flipX)
                Anim.SetTrigger("UpAttack");
            else
                Anim.SetTrigger("UpAttackFlip");
            timeBtwAttack = StartTimeBtwAttack;
        }
        else if(Input.GetMouseButton(0) && Input.GetKey(KeyCode.E))
        {
            OffRegen();
            PlayerCont.Player.State.AttackType = 2;
            if (!playerSprite.flipX)
                Anim.SetTrigger("DownAttack");
            else
                Anim.SetTrigger("DownAttackFlip");
            timeBtwAttack = StartTimeBtwAttack;
        }
        else if(Input.GetMouseButton(0))
        {
            OffRegen();
            PlayerCont.Player.State.AttackType = 3;
            if (!playerSprite.flipX)
                Anim.SetTrigger("MidAttack");
            else
                Anim.SetTrigger("MidAttackFlip");
            timeBtwAttack = StartTimeBtwAttack;
        }
    }

    private void OffRegen()
    {
        PlayerCont.Player.RegenCD = 10f;
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
