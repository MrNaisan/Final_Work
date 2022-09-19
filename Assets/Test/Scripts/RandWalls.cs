using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandWalls : MonoBehaviour
{
    public Sprite[] Walls = new Sprite[5];
    SpriteRenderer sp;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = Walls[Random.Range(0, 5)];
    }
}

