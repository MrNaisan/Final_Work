using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public GameObject Enemy;
    private GameObject player;
    private bool isDeteced;
    public float Speed;
    
    private void Update() 
    {
        Move();
        if (isDeteced)
            MoveToPlayer();
    }

    private void Move()
    {
        
    }

    private void MoveToPlayer()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime * Speed);
    }
    
    public void DetectedPlayerTrue(GameObject player)
    {
        this.player = player;
        isDeteced = true;
    }
    public void DetectedPlayerFalse()
    {
        isDeteced = false;
    }
}
