using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    public SpriteRenderer KatanaSprite;
    public SpriteRenderer PlayerSprite;
    private void Update() 
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        if  (rotateZ > 90  || rotateZ < -90 )
        {
            KatanaSprite.flipY = true;
            PlayerSprite.flipX = true;
        }
        else
        {
            KatanaSprite.flipY = false;
            PlayerSprite.flipX = false;
        }
            
    }
}
