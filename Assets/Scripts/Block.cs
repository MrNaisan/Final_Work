using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isBlock;
    private int blockType;
    private void Update() 
    {
        if(Input.GetMouseButtonDown(1) && Input.GetKey(KeyCode.Q))
        {
            UpBlock();
        }
        else if(Input.GetMouseButtonDown(1) && Input.GetKey(KeyCode.E))
        {
            DownBlock();
        }
        else if(Input.GetMouseButtonDown(1))
        {
            MidBlock();
        }
    }

    private void UpBlock()
    {
        blockType = Player.BlockType;
        if(blockType == Player.AttackType)
        {
        if(Player.Stamina != 0)
            {
                Player.Stamina -= 1;
            }
        else
            Debug.Log("Up Block Fail");
        }
        else
            Debug.Log("Up Block Fail");
    }

    private void DownBlock()
    {
        if(Player.Stamina != 0)
            {
                isBlock = true;
                Player.Stamina -= 1;
            }
        else
            Debug.Log("Down Block Fail");
    }

    private void MidBlock()
    {
        if(Player.Stamina != 0)
            {
                isBlock = true;
                Player.Stamina -= 1;
            }
        else
            Debug.Log("Mid Block Fail");
    }
}



