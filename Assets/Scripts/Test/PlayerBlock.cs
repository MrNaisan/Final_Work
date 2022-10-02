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
           BlockAnimStart();
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetMouseButtonUp(1))
        {
            BlockAnimEnd();
            PlayerCont.Player.State.BlockType = 0;
            StartCoroutine(BlockCD());
        }
        OnBlock();
    }

    private void BlockAnimStart()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerCont.Player.State.BlockType = 1;
            isBlock = false;
            if(!playerSprite.flipX)
                Anim.SetTrigger("UpBlock");
            else
                Anim.SetTrigger("UpBlockFlip");
        }
        else if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            PlayerCont.Player.State.BlockType = 2;
            isBlock = false;
            if(!playerSprite.flipX)
                Anim.SetTrigger("DownBlock");
            else
                Anim.SetTrigger("DownBlockFlip");
        }
        else if(Input.GetMouseButtonDown(1))
        {
            PlayerCont.Player.State.BlockType = 3;
            isBlock = false;
            if(!playerSprite.flipX)
                Anim.SetTrigger("MidBlock");
            else
                Anim.SetTrigger("MidBlockFlip");
        }
    }

    private void BlockAnimEnd()
    {
        if(PlayerCont.Player.State.BlockType == 1)
        {
            if(!playerSprite.flipX)
                Anim.SetTrigger("UpBlockEnd");
            else
                Anim.SetTrigger("UpBlockEndFlip");
        }
        else if(PlayerCont.Player.State.BlockType == 2)
        {
            if(!playerSprite.flipX)
                Anim.SetTrigger("DownBlockEnd");
            else
                Anim.SetTrigger("DownBlockEndFlip");
        }
        else if(PlayerCont.Player.State.BlockType == 3)
        {
            if(!playerSprite.flipX)
                Anim.SetTrigger("MidBlockEnd");
            else
                Anim.SetTrigger("MidBlockEndFlip");
        }
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
