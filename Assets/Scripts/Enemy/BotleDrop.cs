using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotleDrop : MonoBehaviour
{
    public GameObject Hp;
    public GameObject Stamina;

    public void BotleSpawn(Transform enemy)
    {
        var choose = Random.Range(1, 11);
        if (choose == 3)
            Instantiate(Hp, new Vector2(enemy.position.x, enemy.position.y), Quaternion.identity);
        if (choose == 7)
            Instantiate(Stamina, new Vector2(enemy.position.x, enemy.position.y), Quaternion.identity);
    }
}
