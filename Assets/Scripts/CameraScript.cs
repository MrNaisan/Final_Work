using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject PauseMenu;
    public GameObject ContBut;
    public GameObject Text;
    private void Update() 
    {
        if(PlayerCont.Player.State.Hp <= 0)
        {
            PauseMenu.SetActive(true);
            ContBut.SetActive(false);
            Text.SetActive(true);
        }
        else
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, new Vector3 (Player.transform.position.x, Player.transform.position.y, Player.transform.position.z-10), Time.deltaTime*100f);
    }
}
