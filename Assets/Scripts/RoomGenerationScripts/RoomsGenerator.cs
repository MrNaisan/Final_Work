using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsGenerator : MonoBehaviour
{
    [SerializeField]
    private Room roomPrefab;

    private IEnumerator Generate()
    {
        Graph graph = new Graph();
        var infos = graph.Generate1(3);

        foreach (var pos in infos.Keys)
        {
            var room = Instantiate(roomPrefab, new Vector2(pos.x, pos.y) * 22f, Quaternion.identity);
            room.Setup(infos[pos]);

            yield return 0;
        }
    }

    void Start()
    {
        StartCoroutine(Generate());
    }

}
