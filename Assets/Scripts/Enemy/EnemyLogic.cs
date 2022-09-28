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
        Debug.Log("HP " + Enemy.State.Hp);
        Debug.Log("Stamin " + Enemy.State.Stamina);
    }
    private void Update() 
    {
        if (isDeteced)
            MoveToPlayer();
        if (Enemy.State.Hp <= 0)
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
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine(WaitAttack());
        }
    }

    public void BLock()
    {
        if (readyBlock)
        {
            StartCoroutine(BlockCD());
            Enemy.State.BlockType = Enemy.AvailableBlocks[Random.Range(0, Enemy.AvailableBlocks.Count)];
            if (Enemy.State.Stamina != 0)
            {
                if (Enemy.State.BlockType == PlayerCont.Player.State.AttackType)
                {
                    Enemy.State.Stamina -= PlayerCont.Player.State.Damage;
                }
                else
                {
                    Enemy.State.Hp -= PlayerCont.Player.State.Damage;
                    Enemy.State.Stamina -= PlayerCont.Player.State.Damage;
                }
            }
            else
            {
                Enemy.State.Hp -= PlayerCont.Player.State.Damage;
            }
            Debug.Log($"Enemy HP:" + Enemy.State.Hp);
            Debug.Log($"Enemy Stamina:" + Enemy.State.Stamina);
        }
    }

    private void MoveToPlayer()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, Time.deltaTime * Enemy.State.Speed);
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

    IEnumerator BlockCD()
    {
        readyBlock = false;
		yield return new WaitForSeconds(2f);
        readyBlock = true;
    }

    IEnumerator WaitAttack()
    {
        readyAttack = false;
        Enemy.State.AttackType = Enemy.AvailableAttacks[Random.Range(0, Enemy.AvailableAttacks.Count)];
        Debug.Log(Enemy.State.AttackType);
		yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        Enemy.IsAttack = true;
        if (PlayerCont.Player.State.Stamina != 0)
        {
            if (PlayerCont.Player.State.BlockType == Enemy.State.AttackType)
            {
                PlayerCont.Player.State.Stamina -= Enemy.State.Damage;
            }
            else
            {
                PlayerCont.Player.State.Hp -= Enemy.State.Damage;
                PlayerCont.Player.State.Stamina -= Enemy.State.Damage;
            }
        }
        else
        {
            PlayerCont.Player.State.Hp -= Enemy.State.Damage;
        }
        Debug.Log($"Player HP:" + PlayerCont.Player.State.Hp);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(2f);
        readyAttack = true;
    }
}
