using UnityEngine;
using UnityEngine.Tilemaps;

public class Square
{
    public int sideLength { get; set; } = 0;
    public Tile tileType { get; set; }

    public Vector3Int topLeftCorner { get; set; } = new Vector3Int(0, 0, 0);

    public Vector3Int topRightCorner
    {
        get
        {
            return new Vector3Int(
                topLeftCorner.x + (sideLength - 1),
                topLeftCorner.y,
                topLeftCorner.z
            );
        }
    }

    public Vector3Int bottomLeftCorner
    {
        get
        {
            return new Vector3Int(
                topLeftCorner.x,
                topLeftCorner.y - (sideLength - 1),
                topLeftCorner.z
            );
        }
    }

    public Vector3Int bottomRightCorner
    {
        get
        {
            return new Vector3Int(
                topLeftCorner.x + (sideLength - 1),
                topLeftCorner.y - (sideLength - 1),
                topLeftCorner.z
            );
        }
    }

    public Square() { }

    public Square(int sideLength_, Vector3Int topLeftCorner_)
    {
        sideLength = sideLength_;
        topLeftCorner = topLeftCorner_;
    }

    public Tilemap drawToTileMap(Tilemap toDrawOn)
    {
        // TODO: Some level of optimization. I think each corner gets set twice.

        var tlcX = topLeftCorner.x;
        var tlcY = topLeftCorner.y;

        var brcX = bottomRightCorner.x;
        var brcY = bottomRightCorner.y;

        for (var delta = 0; delta < sideLength; delta++)
        {
            // Top horizontal
            toDrawOn.SetTile(new Vector3Int(tlcX + delta, tlcY), tileType);
            // Bot horizontal
            toDrawOn.SetTile(new Vector3Int(tlcX + delta, brcY), tileType);

            // Left Vertical
            toDrawOn.SetTile(new Vector3Int(tlcX, tlcY - delta), tileType);
            // Right Vertical
            toDrawOn.SetTile(new Vector3Int(brcX, tlcY - delta), tileType);
        }

        return toDrawOn;
    }
}
