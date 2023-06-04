using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DarkestDungeonMapGen : MonoBehaviour
{

  public Tile roomTile;
  public Tile hallTile;
  public Tilemap tilemap;

  // Start is called before the first frame update
  void Start()
  {
    tilemap.SetTile(new Vector3Int(0, 0, 0), roomTile);

    buildLine(new Vector2Int(3, 0), new Vector2Int(8, 1));
    // Build the rooms 2nd so they override the halls
    buildRoom(new Vector2Int(3, 0));
    buildRoom(new Vector2Int(8, 1));

  }

  void buildRoom(Vector2Int topLeftCorner)
  {
    // All rooms are 2x2
    square(roomTile, 2, topLeftCorner);

  }

  void buildLine(Vector2Int start, Vector2Int end)
  {
    foreach (Vector2Int pointOnLine in BresenhamLineUtility.getLine_yield(start, end))
    {
      tilemap.SetTile(new Vector3Int(pointOnLine.x, pointOnLine.y), hallTile);
    }
  }





  void square(Tile t, int sideLength, Vector2Int topLeftCorner)
  {
    Vector2Int botRightCorner = new Vector2Int(topLeftCorner.x + sideLength - 1, //
                                               topLeftCorner.y + sideLength - 1);

    // TODO: Some level of optimization. I think each corner gets set twice. 
    int tlcX = topLeftCorner.x;
    int tlcY = topLeftCorner.y;

    int brcX = botRightCorner.x;
    int brcY = botRightCorner.y;

    for (int delta = 0; delta < sideLength; delta++)
    {
      // Top horizontal 
      tilemap.SetTile(new Vector3Int(tlcX + delta, tlcY), t);
      // Bot horizontal 
      tilemap.SetTile(new Vector3Int(tlcX + delta, brcY), t);

      // Left Vertical 
      tilemap.SetTile(new Vector3Int(tlcX, tlcY + delta), t);
      // Right Vertical 
      tilemap.SetTile(new Vector3Int(brcX, tlcY + delta), t);
    }

  }
}
