using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    public SpriteRenderer WeaponSprite;
    public SpriteRenderer EntitySprite;
    private void Update() 
    {
        Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);
        if  (rotateZ > 90  || rotateZ < -90 )
        {
            WeaponSprite.flipY = true;
            EntitySprite.flipX = true;
        }
        else
        {
            WeaponSprite.flipY = false;
            EntitySprite.flipX = false;
        }
            
    }
}
