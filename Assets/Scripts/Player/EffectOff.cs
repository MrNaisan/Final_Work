using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOff : MonoBehaviour
{
    public GameObject Effect;

    public void OffEffect()
    {
        Effect.SetActive(false);
    }
}
