using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * A simple data storage class used to map UnityEngine.Tilemaps.TileBase 
 * objects to NocabTile scriptable behaviours.
 */
public class TileToScriptMapper : MonoBehaviour
{
    public TileBase[] tiles;
    public NocabTile scriptForTiles;
}
