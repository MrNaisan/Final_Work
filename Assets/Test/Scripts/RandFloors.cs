using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandFloors : MonoBehaviour
{
    public Sprite[] Floors = new Sprite[2];
    SpriteRenderer sp;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = Floors[Random.Range(0, 2)];
    }
}
