using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRengeScript : MonoBehaviour
{
    public EnemyLogic Logic;
    private Coroutine updateCor;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent<PlayerCollider>(out _))
        {
            Logic.DetectedPlayerFalse();
            Logic.IsPlayerOnTrigger = true;
            updateCor = StartCoroutine(UpdateTrig());
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.TryGetComponent<PlayerCollider>(out _))
        {
            StopCoroutine(updateCor);
            Logic.IsPlayerOnTrigger = false;
            Logic.DetectedPlayerTrue(other.gameObject);
        }
    }

    IEnumerator UpdateTrig()
    {
        while(true)
        {
            if (PlayerCont.Player.State.AttackType == 0)
                Logic.TriggerAttack();
            yield return new WaitForSeconds(1f);
        }
    }
}
