using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private int rand;
    public GameObject Enemy;
    private GameObject Player;
    private bool isDeteced;
    public float Speed;
    
    private void Start() 
    {
        Player = GameObject.FindGameObjectWithTag("player");
    }
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
        this.transform.position = Vector3.MoveTowards(this.transform.position, Player.transform.position, Time.deltaTime * Speed);
    }
    
    public void DetectedPlayerTrue()
    {
        isDeteced = true;
    }
    public void DetectedPlayerFalse()
    {
        isDeteced = false;
    }
}
