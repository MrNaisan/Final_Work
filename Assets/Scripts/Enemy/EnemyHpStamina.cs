using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHpStamina : MonoBehaviour
{
    public Image HpBar;
    public Image StaminaBar;
    private float maxHp;
    private float maxStamina;
    public EnemyLogic Logic;

    private void Start() 
    {
        maxHp = Logic.Enemy.State.Hp;
        maxStamina = Logic.Enemy.State.Stamina;
    }

    private void Update()
    {
        HpBar.fillAmount = Logic.Enemy.State.Hp / maxHp;
        StaminaBar.fillAmount = Logic.Enemy.State.Stamina / maxStamina;
    }
}
