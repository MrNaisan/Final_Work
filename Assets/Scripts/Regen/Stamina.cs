using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public void RegenStamina()
    {
        if (PlayerCont.Player.State.Stamina <= 7)
            PlayerCont.Player.State.Stamina += 3;
        else
            PlayerCont.Player.State.Stamina = 10;
        Destroy(this.gameObject);
    }
}
