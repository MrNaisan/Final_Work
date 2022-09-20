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
            PlayerAttack(1);
        }
        else if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.E))
        {
            PlayerAttack(2);
        }
        else if(Input.GetMouseButtonDown(0))
        {
            PlayerAttack(3);
        }
        if (Player.instance.Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.TryGetComponent<EnemyLogic>(out EnemyLogic enemy))
        {
            isAttack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.TryGetComponent<EnemyLogic>(out EnemyLogic enemy))
        {
            isAttack = false;
        }
    }

    private void PlayerAttack(int AttackNum)
    {
        if(readyAttack)
        {
            if(isAttack)
            {
                Player.instance.AttackType = AttackNum;
            }
            StartCoroutine(CD());
        }
    }

    IEnumerator CD()
    {
        readyAttack = false;
		yield return new WaitForSeconds(3f);
        Player.instance.AttackType = 0;
        readyAttack = true;
    }
}
