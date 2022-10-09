using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject PlayerObj;
    private float Speed;
    private float maxHp;
    private float maxStamina;
    private bool readyHpRegen;

    private void Start() 
    {
        StartCoroutine(StaminaRegen());
        maxHp = PlayerCont.Player.State.Hp;
        maxStamina = PlayerCont.Player.State.Stamina;
        Speed = PlayerObj.GetComponent<Player>().State.Speed;
    }
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
        PlayerCont.Player.RegenCD -= Time.deltaTime;
    }

    IEnumerator StaminaRegen()
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);
            if(PlayerCont.Player.State.Stamina < maxStamina && PlayerCont.Player.RegenCD <= 0)
                PlayerCont.Player.State.Stamina++;
        }
    }

    private void Move(Vector3 Vector3)
    {
        var position = PlayerObj.transform.position;
        position = position+Vector3 * Speed *Time.deltaTime;
        PlayerObj.transform.position = position;
    }
}
