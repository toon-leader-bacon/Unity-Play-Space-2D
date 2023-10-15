using UnityEngine;
using UnityEngine.Tilemaps;

public class Line
{
    public Tile tileType { get; set; }

    public Vector2Int startingPoint { get; set; } = new Vector2Int(0, 0);
    public Vector2Int endingPoint { get; set; } = new Vector2Int(0, 0);

    public Line() { }

    public Line(Vector3Int startingPoint_, Vector3Int endingPoint_)
    {
        startingPoint = (Vector2Int)startingPoint_;
        endingPoint = (Vector2Int)endingPoint_;
    }

    public Line(Vector2Int startingPoint_, Vector2Int endingPoint_)
    {
        startingPoint = startingPoint_;
        endingPoint = endingPoint_;
    }

    public Tilemap drawToTileMap(Tilemap toDrawOn)
    {
        foreach (
            Vector2Int pointOnLine in BresenhamLineUtility.getLine_yield(
                startingPoint,
                endingPoint,
                BresenhamLineUtility.FatLineStyle.XIncrement
            )
        )
        {
            toDrawOn.SetTile(new Vector3Int(pointOnLine.x, pointOnLine.y), tileType);
        }
        return toDrawOn;
    }
}
