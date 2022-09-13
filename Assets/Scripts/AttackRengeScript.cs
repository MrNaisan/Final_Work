using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackRengeScript : MonoBehaviour
{
    public UnityEvent AttackRenge;
    void OnTriggerStay2D(Collider2D coll) 
    {
        if (coll.tag == "player")
        {
            AttackRenge.Invoke();
        }
    }
}
