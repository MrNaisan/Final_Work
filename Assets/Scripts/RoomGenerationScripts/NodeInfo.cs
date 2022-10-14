using System.Collections.Generic;
using UnityEngine;

public class NodeInfo
{
    public Vector2Int Pos;
    public List<Vector2Int> Dirs;

    public NodeInfo(Vector2Int pos, List<Vector2Int> dirs)
    {
        Pos = pos;
        Dirs = dirs;
    }
}