using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandFloors : MonoBehaviour
{
    public Sprite[] Floors;
    SpriteRenderer sp;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = Floors[Random.Range(0, Floors.Length)];
    }
}
