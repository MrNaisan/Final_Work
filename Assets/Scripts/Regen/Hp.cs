using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour
{
    public void RegenHp()
    {
        PlayerCont.Player.State.Hp = Mathf.Clamp(PlayerCont.Player.State.Hp+3, 1, 10);
        Destroy(this.gameObject);
    }
}
