using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public TileToScriptMapper[] maps;

    protected Dictionary<TileBase, NocabTile> tileToScript;

    // Start is called before the first frame update
    void Start()
    {
        compileTileToScript();
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

}
