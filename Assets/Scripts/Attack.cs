using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool isAttack;
    private bool readyAttack = true;
    private GameObject enemy;
    
    private void Update() 
    {
        if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Q))
        {
            Player.instance.AttackType = 1;
            PlayerAttack();
        }
        else if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.E))
        {
            Player.instance.AttackType = 3;
            PlayerAttack();
        }
        else if(Input.GetMouseButtonDown(0))
        {
            Player.instance.AttackType = 2;
            PlayerAttack();
        }
        if (Player.instance.Hp <=0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.TryGetComponent<EnemyLogic>(out EnemyLogic enemy))
        {
            isAttack = true;
            this.enemy = enemy.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.TryGetComponent<EnemyLogic>(out EnemyLogic enemy))
        {
            isAttack = false;
            this.enemy = null;
        }
    }

    private void PlayerAttack()
    {
        if(readyAttack)
        {
            if(isAttack)
            {
                if(enemy.TryGetComponent<EnemyLogic>(out EnemyLogic enemyStats))
                {
                    if (enemyStats.Enemy.Stamina != 0)
                    {
                        if (enemyStats.Enemy.BlockType == Player.instance.AttackType)
                        {
                            enemyStats.Enemy.Stamina -= Player.instance.Damage;
                        }
                        else
                        {
                            enemyStats.Enemy.Hp -= Player.instance.Damage;
                            enemyStats.Enemy.Stamina -= Player.instance.Damage;
                        }
                    }
                    else
                    {
                        enemyStats.Enemy.Hp -= Player.instance.Damage;
                    }
                    Debug.Log("HP " + enemyStats.Enemy.Hp);
                    Debug.Log("Stamin " + enemyStats.Enemy.Stamina);
                }
            }
            StartCoroutine("CD");
            Player.instance.AttackType = 0;
        }
    }

    IEnumerator CD()
    {
        readyAttack = false;
		yield return new WaitForSeconds(3f);
        readyAttack = true;
    }
}
