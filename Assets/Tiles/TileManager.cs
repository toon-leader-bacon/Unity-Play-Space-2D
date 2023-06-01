using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
  public TileToScriptMapper[] maps;

  protected Dictionary<TileBase, NocabTile> tileToScript = new Dictionary<TileBase, NocabTile>();
  protected Tilemap tileMap;

  // Start is called before the first frame update
  void Start()
  {
    tileMap = GetComponentInChildren<Tilemap>();

    compileTileToScript();
    // TODO: Iterate over all the TileToScriptManagers in this Grid object and grab them that way
  }

  void compileTileToScript()
  {
    // Process all the maps and aggregate them into a single massive map
    foreach (TileToScriptMapper map in maps)
    {
      foreach (Tile tile in map.tiles)
      {
        tileToScript[tile] = map.scriptForTiles;
      }
      // The mapping object is no longer needed once it's data is added to this tileToScript field
      Destroy(map);
    }
  }

  public NocabTile UnityToNocabTile(TileBase unityTileType)
  {
    return tileToScript[unityTileType];
  }

  public NocabTile GetTileAtPosition(Vector3Int pos)
  {
    return UnityToNocabTile(tileMap.GetTile(pos));
  }
  
  public NocabTile GetTileAtPosition(Vector3 pos)
  {
    Vector3Int posInt = new Vector3Int(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), Mathf.FloorToInt(pos.z));
    return GetTileAtPosition(posInt);
  }

}
