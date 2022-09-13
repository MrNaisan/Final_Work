using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Player;
    public float Speed = 1f;

    private void Update()   
    {
        if(Input.GetKey(KeyCode.W))
        {
            Move(new Vector3(0, 1, 0));
        }
        if(Input.GetKey(KeyCode.S))
        {
            Move(new Vector3(0, -1, 0));
        }
        if(Input.GetKey(KeyCode.A))
        {
            Move(new Vector3(-1, 0, 0));
            
        }
        if(Input.GetKey(KeyCode.D))
        {
            Move(new Vector3(1, 0, 0));
            
        }
    }

    private void Move(Vector3 Vector3)
    {
        Player.transform.Translate(Vector3 * Speed * Time.deltaTime);
    }
}
