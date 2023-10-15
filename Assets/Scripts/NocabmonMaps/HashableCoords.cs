using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashableCoord : MonoBehaviour
{
    public HashableCoord(Vector2Int coord_)
    {
        this.coord = coord_;
    }

    public HashableCoord(int x, int y)
    {
        this.coord = new Vector2Int(x, y);
    }

    public HashableCoord()
    {
        this.coord = Vector2Int.zero;
    }

    public Vector2Int coord = Vector2Int.zero;

    public override int GetHashCode()
    {
        return NocabHashUtility.generateHash(coord.x, coord.y);
    }
}
