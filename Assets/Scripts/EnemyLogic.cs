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
    private bool readyBlock = true;
    private bool waitAttack = true;

    private void Awake() 
    {
        Enemy = new Enemy(Hp, Stamin, Damage, AvailableAttacks, AvailableBlocks, Speed);
        Debug.Log("HP " + Enemy.Hp);
        Debug.Log("Stamin " + Enemy.Stamina);
    }
    private void Update() 
    {
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
        if (readyAttack)
        {
            StartCoroutine(AttackCD());
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine(WaitAttack());
        }
    }

    public void BLock()
    {
        if (readyBlock)
        {
            StartCoroutine(BlockCD());
            Enemy.BlockType = Enemy.AvailableBlocks[Random.Range(0, Enemy.AvailableBlocks.Count)];
            if (Enemy.Stamina != 0)
            {
                if (Enemy.BlockType == Player.instance.AttackType)
                {
                    Enemy.Stamina -= Player.instance.Damage;
                }
                else
                {
                    Enemy.Hp -= Player.instance.Damage;
                    Enemy.Stamina -= Player.instance.Damage;
                }
            }
            else
            {
                Enemy.Hp -= Player.instance.Damage;
            }
            Debug.Log(Enemy.Hp);
        }
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
    
    IEnumerator AttackCD()
    {
        readyAttack = false;
		yield return new WaitForSeconds(3f);
        readyAttack = true;
    }

    IEnumerator BlockCD()
    {
        readyBlock = false;
		yield return new WaitForSeconds(2f);
        readyBlock = true;
    }

    IEnumerator WaitAttack()
    {
		yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        Enemy.IsAttack = true;
        Enemy.AttackType = Enemy.AvailableAttacks[Random.Range(0, Enemy.AvailableAttacks.Count)];
        Debug.Log(Enemy.AttackType);
        if (Player.instance.Stamina != 0)
        {
            if (Player.instance.BlockType == Enemy.AttackType)
            {
                Player.instance.Stamina -= Enemy.Damage;
            }
            else
            {
                Player.instance.Hp -= Enemy.Damage;
                Player.instance.Stamina -= Enemy.Damage;
            }
        }
        else
        {
            Player.instance.Hp -= Enemy.Damage;
        }
        Debug.Log(Player.instance.Hp);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
