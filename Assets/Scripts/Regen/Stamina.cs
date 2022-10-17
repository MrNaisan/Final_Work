using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public void RegenStamina()
    {
        PlayerCont.Player.State.Stamina = Mathf.Clamp(PlayerCont.Player.State.Stamina+3, 1, 10);
        Destroy(this.gameObject);
    }
}
