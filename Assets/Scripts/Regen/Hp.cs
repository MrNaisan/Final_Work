using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public void RegenHp()
    {
        if (PlayerCont.Player.State.Hp <= 7)
            PlayerCont.Player.State.Hp += 3;
        else
            PlayerCont.Player.State.Hp = 10;
        Destroy(this.gameObject);
    }
}
