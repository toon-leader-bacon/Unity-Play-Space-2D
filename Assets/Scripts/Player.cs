using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
  public Tilemap tileMap;
  public TileManager tileManager;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    MoveCheck();
    CheckCurrentTile();
  }

  void CheckCurrentTile()
  {
    if (Input.GetKeyDown("space"))
    {
      NocabTile currentTile = tileManager.GetTileAtPosition(this.transform.position);
      currentTile.onEnter();
    }
  }

  void MoveCheck()
  {
    int verticalDir = 0;
    if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
    {
      verticalDir = 1;
    }
    else if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
    {
      verticalDir = -1;
    }

    int horizDir = 0;
    if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
    {
      horizDir = 1;
    }
    else if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
    {
      horizDir = -1;
    }

    Vector3 newPos = this.transform.position + new Vector3(horizDir, verticalDir);
    NocabTile newTile = tileManager.GetTileAtPosition(newPos);
    if (newTile.walkable)
    {
      this.transform.position = newPos;
    }
    else
    {
      Debug.Log($"Can't walk onto other tile of type: {newTile.name}");
    }

  }

}
