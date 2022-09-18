using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isBlock;
    private GameObject enemy;
    private bool readyBlock;

    private void Update() 
    {
        if(Input.GetMouseButtonDown(1) && Input.GetKey(KeyCode.Q))
        {
            Player.instance.BlockType = 1;
            PlayerBlock();
        }
        else if(Input.GetMouseButtonDown(1) && Input.GetKey(KeyCode.E))
        {
            Player.instance.BlockType = 3;
            PlayerBlock();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            Player.instance.BlockType = 2;
            PlayerBlock();
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
            isBlock = true;
            this.enemy = enemy.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.TryGetComponent<EnemyLogic>(out EnemyLogic enemy))
        {
            isBlock = false;
            this.enemy = null;
        }
    }

    private void PlayerBlock()
    {
        if(isBlock)
        {
            if(enemy.TryGetComponent<EnemyLogic>(out EnemyLogic enemyStats))
            {
                Debug.Log(enemyStats.Enemy.IsAttack);
                if(enemyStats.Enemy.IsAttack)
                {
                    if (Player.instance.Stamina != 0)
                    {
                        if (Player.instance.BlockType == enemyStats.Enemy.AttackType)
                        {
                            Player.instance.Stamina -= enemyStats.Enemy.Damage;
                        }
                        else
                        {
                            Player.instance.Hp -= enemyStats.Enemy.Damage;
                            Player.instance.Stamina -= enemyStats.Enemy.Damage;
                        }   
                    }
                    else
                    {
                        Player.instance.Hp -= enemyStats.Damage;
                    }
                }
            }
        }
        StartCoroutine("CD");
    }

    IEnumerator CD()
    {
        readyBlock = false;
		yield return new WaitForSeconds(3f);
        readyBlock = true;
    }
}



