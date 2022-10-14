using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
    private void Update() 
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, new Vector3 (Player.transform.position.x, Player.transform.position.y, Player.transform.position.z-10), Time.deltaTime*100f);
    }
}
