using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandWalls : MonoBehaviour
{
    public Sprite[] Walls;
    SpriteRenderer sp;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = Walls[Random.Range(0, Walls.Length)];
    }
}

