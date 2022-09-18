using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    private GameObject player;
    private bool isDeteced;
    public float Speed;
    public Enemy Enemy;
    public float Hp;
    public float Stamin;
    public float Damage;
    public List<int> AvailableBlocks;
    public List<int> AvailableAttacks;
    private bool readyAttack = true;

    private void Awake() 
    {
        Enemy = new Enemy(Hp, Stamin, Damage, AvailableAttacks, AvailableBlocks, Speed);
        Debug.Log("HP " + Enemy.Hp);
        Debug.Log("Stamin " + Enemy.Stamina);
    }
    private void Update() 
    {
        Move();
        if (isDeteced)
            MoveToPlayer();
        else
            Move();
        if (Enemy.Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Move()
    {
        
    }

    public void Attack()
    {
        Enemy.IsAttack = true;
        if (readyAttack)
        {
            Enemy.AttackType = Enemy.AvailableAttacks[Random.Range(0, Enemy.AvailableAttacks.Count)];
            Debug.Log(Enemy.AttackType);
            StartCoroutine("CD");
        }
        
    }

    public void BLock()
    {

    }

    private void MoveToPlayer()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime * Enemy.Speed);
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
    
    IEnumerator CD()
    {
        readyAttack = false;
		yield return new WaitForSeconds(3f);
        readyAttack = true;
    }
}
