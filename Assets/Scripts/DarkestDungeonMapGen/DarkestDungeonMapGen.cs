using System.Collections.Generic;
using UnityEditor;
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

    Square r1 = new Square(2, new Vector3Int(0, 0, 0));
    Square r2 = new Square(2, new Vector3Int(8, 0, 0));
    Square r3 = new Square(2, new Vector3Int(16, 0, 0));
    Square r4 = new Square(2, new Vector3Int(8, 8, 0));
    r1.tileType = roomTile;
    r2.tileType = roomTile;
    r3.tileType = roomTile;
    r4.tileType = roomTile;

    Line l12 = new Line(r1.topRightCorner, r2.bottomLeftCorner);
    Line l23 = new Line(r2.bottomRightCorner, r3.bottomLeftCorner);
    Line l24 = new Line(r2.topRightCorner, r4.bottomLeftCorner);
    l12.tileType = hallTile;
    l23.tileType = hallTile;
    l24.tileType = hallTile;

    l12.drawToTileMap(tilemap);
    l23.drawToTileMap(tilemap);
    l24.drawToTileMap(tilemap);

    r1.drawToTileMap(tilemap);
    r2.drawToTileMap(tilemap);
    r3.drawToTileMap(tilemap);
    r4.drawToTileMap(tilemap);
  }

}
