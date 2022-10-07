using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isBlock;
    private bool readyBlock = true;
    
    private void Update() 
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            PlayerBlock(1);
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            PlayerBlock(2);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            PlayerBlock(3);
        }
        if (PlayerCont.Player.State.Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.TryGetComponent<EnemyLogic>(out EnemyLogic enemy))
        {
            isBlock = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.TryGetComponent<EnemyLogic>(out EnemyLogic enemy))
        {
            isBlock = false;
        }
    }

    private void PlayerBlock(int BlockNum)
    {
        if(readyBlock)
        {
            if(isBlock)
            {
                PlayerCont.Player.State.BlockType = BlockNum;
            }
            StartCoroutine(CD(2f));
        }
    }

    IEnumerator CD(float time)
    {
        readyBlock = false;
		yield return new WaitForSeconds(time);
        PlayerCont.Player.State.AttackType = 0;
        readyBlock = true;
    }
}
