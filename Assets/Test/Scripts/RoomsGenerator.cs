using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsGenerator : MonoBehaviour
{
    [SerializeField]
    private Room roomPrefab;
    public int GenerateRooms=20;

    private IEnumerator Generate()
    {
        Graph graph = new Graph();
        var infos = graph.Generate1(GenerateRooms);

        foreach (var pos in infos.Keys)
        {
            var room = Instantiate(roomPrefab, new Vector3(pos.x, pos.y) * 20f, Quaternion.identity);
            room.Setup(infos[pos]);

            yield return 0;
        }
    }

    void Start()
    {
        StartCoroutine(Generate());
    }

}
