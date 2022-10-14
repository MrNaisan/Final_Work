using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ViewFieldScript : MonoBehaviour
{
    public EnemyLogic Logic;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.TryGetComponent<PlayerCollider>(out _))
            Logic.DetectedPlayerTrue(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.TryGetComponent<PlayerCollider>(out _))
            Logic.DetectedPlayerFalse();
    }
}
