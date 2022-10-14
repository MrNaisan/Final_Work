using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private Openings walls;
    [SerializeField]
    private GameObject[] bridgesArray;
    [SerializeField]
    private GameObject[] wallsArray;
    public void Setup(HashSet<Vector2Int> config)
    {
        foreach (var wall in walls.GetOpenings())
        {
            bool contains = config.Contains(wall.Pos);
            wall.GameObject.SetActive(!contains);
        }
        for (int i = 0; i < wallsArray.Length; i++)
        {
            if (wallsArray[i].activeSelf)
            {
                bridgesArray[i].SetActive(false);
            }
        }
    }
}
