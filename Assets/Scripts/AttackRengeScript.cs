using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRengeScript : MonoBehaviour
{
    public EnemyLogic Logic;
    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.TryGetComponent<Attack>(out Attack attack))
        {
            if (Player.instance.AttackType != 0)
                Logic.BLock();
            else
                Logic.Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        Logic.StopCoroutine("WaitAttack");
    }
}
