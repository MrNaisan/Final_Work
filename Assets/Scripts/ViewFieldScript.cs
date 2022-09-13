using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ViewFieldScript : MonoBehaviour
{
    public EnemyLogic Logic;
    void OnTriggerStay2D(Collider2D other) 
    {
        if (other.TryGetComponent<Attack>(out Attack attack))
            Logic.DetectedPlayerTrue();
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if (other.TryGetComponent<Attack>(out Attack attack))
            Logic.DetectedPlayerFalse();
    }
}