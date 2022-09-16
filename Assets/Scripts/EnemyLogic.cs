using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private GameObject player;
    private bool isDeteced;
    public float Speed;
    public Enemy Enemy;
    
    private void Awake() 
    {
        Enemy = new Enemy(10, 10, 1);
        Debug.Log("HP " + Enemy.Hp);
        Debug.Log("Stamin " + Enemy.Stamina);
    }
    private void Update() 
    {
        Move();
        if (isDeteced)
            MoveToPlayer();
        if (Enemy.Hp <= 0)
        {
            Destroy(this.gameObject);
        }
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
