using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject PauseMenu;
    public GameObject ContBut;
    public Text Text;
    public Text NumEnemys;
    private EnemyLogic[] enemyLogic;
    private bool isCheck;

    private void Update() 
    {
        if (enemyLogic != null)
            isCheck = true;
        enemyLogic = FindObjectsOfType<EnemyLogic>();
        NumEnemys.text = enemyLogic.Length.ToString();
        if(PlayerCont.Player.State.Hp <= 0)
        {
            Ui("You Lose!");
        }
        else if(enemyLogic.Length == 0 && isCheck)
        {
            Ui("You Won!");
        }
        else
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, new Vector3 (Player.transform.position.x, Player.transform.position.y, Player.transform.position.z-10), Time.deltaTime*100f);
    }

    private void Ui(string text)
    {
        PauseMenu.SetActive(true);
        ContBut.SetActive(false);
        Text.gameObject.SetActive(true);
        Text.text = text;
    }
}
