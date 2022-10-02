using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public Image HpBar;
    public Image StaminaBar;
    private float maxHp;
    private float maxStamina;

    private void Start() 
    {
        maxHp = PlayerCont.Player.State.Hp;
        maxStamina = PlayerCont.Player.State.Stamina;
    }

    private void Update()
    {
        HpBar.fillAmount = PlayerCont.Player.State.Hp / maxHp;
        StaminaBar.fillAmount = PlayerCont.Player.State.Stamina / maxStamina;
    }

}
