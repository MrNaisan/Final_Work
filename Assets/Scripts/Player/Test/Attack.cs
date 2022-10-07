using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool IsAttack;
    private bool readyAttack = true;
    public Animator KatanaAnim;
    private SpriteRenderer playerSprite;

    private void Start()
    {
        playerSprite = this.GetComponent<SpriteRenderer>();
    }
    private void Update() 
    {
        if (readyAttack)
        {
            if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Q))
            {
                if (!playerSprite.flipX)
                    KatanaAnim.SetTrigger("UpAttack");
                else
                    KatanaAnim.SetTrigger("UpAttackFlip");
                PlayerAttack(1);
            }
            else if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.E))
            {
                if (!playerSprite.flipX)
                    KatanaAnim.SetTrigger("DownAttack");
                else
                    KatanaAnim.SetTrigger("DownAttackFlip");
                PlayerAttack(2);
            }
            else if(Input.GetMouseButtonDown(0))
            {
                if (!playerSprite.flipX)
                    KatanaAnim.SetTrigger("MidAttack");
                else
                    KatanaAnim.SetTrigger("MidAttackFlip");
                PlayerAttack(3);
            }
        }

    }


    private void PlayerAttack(int AttackNum)
    {
        StartCoroutine(CD(3f));
        if(IsAttack)
        {
            
            Debug.Log("attack");
            PlayerCont.Player.State.AttackType = AttackNum;
            IsAttack = false;
        }
    }

    IEnumerator CD(float time)
    {
        readyAttack = false;
		yield return new WaitForSeconds(time);
        PlayerCont.Player.State.AttackType = 0;
        readyAttack = true;
    }
}
