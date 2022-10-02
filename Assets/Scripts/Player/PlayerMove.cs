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
    private bool readyStaminaRegen = true;

    private void Start() 
    {
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
        if(PlayerCont.Player.RegenCD <= 0)
        {
            if(readyStaminaRegen)
                if(PlayerCont.Player.State.Stamina < maxStamina)
                    StartCoroutine(StaminaRegen());
        }
        PlayerCont.Player.RegenCD -= Time.deltaTime;
    }

    IEnumerator StaminaRegen()
    {
        readyStaminaRegen = false;
        yield return new WaitForSeconds(3f);
        PlayerCont.Player.State.Stamina++;
        readyStaminaRegen = true;
    }

    private void Move(Vector3 Vector3)
    {
        PlayerObj.transform.Translate(Vector3 * Speed * Time.deltaTime);
    }
}
