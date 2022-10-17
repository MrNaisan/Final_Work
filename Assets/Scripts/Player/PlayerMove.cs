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
    public Animator Anim;

    private void Start() 
    {
        StartCoroutine(StaminaRegen());
        maxHp = PlayerCont.Player.State.Hp;
        maxStamina = PlayerCont.Player.State.Stamina;
        Speed = PlayerCont.Player.State.Speed;
    }
    private void Update()   
    {
        if(PlayerCont.Player.State.Hp <= 0)
            this.gameObject.SetActive(false);
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
        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            Anim.SetBool("IsMove", false);
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
        Anim.SetBool("IsMove", true);
        var position = PlayerObj.transform.position;
        position = position+Vector3 * Speed *Time.deltaTime;
        PlayerObj.transform.position = position;
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (Input.GetKey(KeyCode.E))
        {
            if(other.TryGetComponent<Hp>(out Hp hp))
                hp.RegenHp();
            if(other.TryGetComponent<Stamina>(out Stamina stamina))
                stamina.RegenStamina();
        }
    }
}
