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
        if (other.TryGetComponent<Player>(out Player player))
        {
            Logic.DetectedPlayerFalse();
            updateCor = StartCoroutine(UpdateTrig());
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            StopCoroutine(updateCor);
            Logic.DetectedPlayerTrue(other.gameObject);
        }
    }

    IEnumerator UpdateTrig()
    {
        while(true)
        {
            if (PlayerCont.Player.State.AttackType == 0)
                Logic.Attack();
            yield return new WaitForSeconds(1f);
        }
    }
}
