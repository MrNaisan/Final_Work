using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool isAttack;
    private bool readyAttack = true;
    public Animator Katana;
    private SpriteRenderer PlayerSprite;

    private void Start()
    {
        PlayerSprite = this.GetComponent<SpriteRenderer>();
    }
    private void Update() 
    {
        if (readyAttack)
        {
            if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Q))
            {
                if (!PlayerSprite.flipX)
                    Katana.SetTrigger("UpAttack");
                else
                    Katana.SetTrigger("UpAttackFlip");
                PlayerAttack(1);
            }
            else if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.E))
            {
                if (!PlayerSprite.flipX)
                    Katana.SetTrigger("DownAttack");
                else
                    Katana.SetTrigger("DownAttackFlip");
                PlayerAttack(2);
            }
            else if(Input.GetMouseButtonDown(0))
            {
                if (!PlayerSprite.flipX)
                    Katana.SetTrigger("MidAttack");
                else
                    Katana.SetTrigger("MidAttackFlip");
                PlayerAttack(3);
            }
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
            PlayerCont.Player.State.AttackType = 0;
        }
    }

    private void PlayerAttack(int AttackNum)
    {
        StartCoroutine(CD(3f));
        if(isAttack)
        {
            PlayerCont.Player.State.AttackType = AttackNum;
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
