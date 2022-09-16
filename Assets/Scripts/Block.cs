using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
   private bool isBlock;
    private GameObject enemy;
    
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
            if(enemy.TryGetComponent<Enemy>(out Enemy enemyStats))
            {
                if (Player.instance.Stamina != 0)
                {
                    if (Player.instance.BlockType == enemyStats.AttackType)
                    {
                        Player.instance.Stamina -= enemyStats.Damage;
                    }
                    else
                    {
                        Player.instance.Hp -= enemyStats.Damage;
                        Player.instance.Stamina -= enemyStats.Damage;
                    }
                }
                else
                {
                    Player.instance.Hp -= enemyStats.Damage;
                }
            }
        }
        StartCoroutine("CD");
    }

    IEnumerator CD()
    {
        isBlock = false;
		yield return new WaitForSeconds(3f);
    }
}



