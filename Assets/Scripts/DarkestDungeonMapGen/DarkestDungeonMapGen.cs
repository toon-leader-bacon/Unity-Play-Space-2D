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

    lineOfRooms(firstRoomTL: new Vector2Int(0, 5), directionBetweenRooms: new Vector2Int(5, 0), numberOfRooms: 4);


    // buildLine(new Vector2Int(3, 0), new Vector2Int(8, 1));
    // buildLine(new Vector2Int(3, 0), new Vector2Int(6, 8));
    // // Build the rooms 2nd so they override the halls
    // buildRoom(new Vector2Int(3, 0));
    // buildRoom(new Vector2Int(8, 1));
    // buildRoom(new Vector2Int(6, 8));

  }

  void buildRoom(Vector2Int topLeftCorner, int roomSize = 2)
  {
    square(roomTile, roomSize, topLeftCorner);
  }

  void buildLine(Vector2Int start, Vector2Int end)
  {
    foreach (Vector2Int pointOnLine in BresenhamLineUtility.getLine_yield(start, end, BresenhamLineUtility.FatLineStyle.XIncrement))
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

  void lineOfRooms(Vector2Int firstRoomTL, Vector2Int directionBetweenRooms, int numberOfRooms, int roomSize = 2)
  {
    // Vector2Int firstRoomTL = new Vector2Int(5, 0);
    // Vector2Int directionBetweenRooms = new Vector2Int(5, 0);
    // int numberOfRooms = 4;
    // int roomSize = 2;

    // Draw the first room
    buildRoom(firstRoomTL, roomSize);

    // Start the loop from index 1 b/c we've already drawn the first room
    for (int i = 1; i < numberOfRooms; i++)
    {
      // Draw the hall from the prev room to the cur room
      // This avoids an off by one issue where we draw a final hallway to nowhere
      Vector2Int currRoomTL = firstRoomTL + (i * directionBetweenRooms);
      Vector2Int prevRoomTl = currRoomTL - directionBetweenRooms;
      buildLine(prevRoomTl, currRoomTL);

      // Build the current room
      buildRoom(currRoomTL, roomSize);
    }
  }

  void boxOfRooms()
  {
    int tlX = 5;
    int tlY = 0;

    int roomsInXDir = 2;
    int roomsInYDir = 2;

    int hallDistance = 5;
    int roomSize = 2;

    for (int roomX = 0; roomX < roomsInXDir; roomX++)
    {

    }
  }
}
