using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int Damage;
    private bool isAttack;
    public int Damage1;
    
    private void Start() 
    {
        
    }
    private void Update() 
    {
        if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Q))
        {
            UpAttack();
        }
        else if(Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.E))
        {
            DownAttack();
        }
        else if(Input.GetMouseButtonDown(0))
        {
            MidAttack();
        }

    }

    private void UpAttack()
    {
        if(isAttack)
        {
            
        }
    }

    private void DownAttack()
    {
        if(isAttack)
        {
            Debug.Log("Down");
        }
    }

    private void MidAttack()
    {
        if(isAttack)
        {
            Debug.Log("Mid");
        }
    }

    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Damage1 = enemy.UpBlock() - (Damage/10);
            isAttack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.TryGetComponent<Enemy>(out Enemy enemy))
        {
            isAttack = false;
        }
    }

}
