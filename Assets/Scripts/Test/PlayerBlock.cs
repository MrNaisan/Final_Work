using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlock : MonoBehaviour
{
    private bool isBlock;
    public Transform BlockPos;
    public LayerMask Enemy;
    public float BlockRange;
    public Animator Anim;
    public SpriteRenderer playerSprite;

    private void Update()
    {
        if (isBlock)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                PlayerCont.Player.State.BlockType = 1;
                isBlock = false;
            }
            else if(Input.GetKeyDown(KeyCode.LeftAlt))
            {
                PlayerCont.Player.State.BlockType = 2;
                isBlock = false;
            }
            else if(Input.GetMouseButtonDown(1))
            {
                PlayerCont.Player.State.BlockType = 3;
                isBlock = false;
            }
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetMouseButtonUp(1))
        {
            PlayerCont.Player.State.BlockType = 0;
            StartCoroutine(BlockCD());
        }
        OnBlock();
    }

    IEnumerator BlockCD()
    {
        yield return new WaitForSeconds(1f);
        isBlock = true;
    }
    public void OnBlock()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(BlockPos.position, BlockRange, Enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyLogic>().IsBlocked = true;
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(BlockPos.position, BlockRange);
    }
}
