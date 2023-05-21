using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouseOverTileTracker : MonoBehaviour
{
    /**
     * A tool to help click on/ mouse over various tiles in a TileMap
     * Attach this script to a Grid TileMap top level parent object
     */

    private Grid grid;
    private Tilemap tileMap;

    // Start is called before the first frame update
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
        tileMap = gameObject.GetComponentInChildren<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(GetTileUnderMouse_XYZ());

        if (Input.GetMouseButtonUp(0))
        { // Left 
            Debug.Log("Left button up");
            TileBase tileBaseClicked = GetTileBaseUnderMouse();
            TileManager lookup = gameObject.GetComponent<TileManager>();
            NocabTile tileClicked = lookup.UnityToNocabTile(tileBaseClicked);
            tileClicked.onClick();
        }
    }

    Vector3Int GetTileUnderMouse_XYZ()
    {
        /**
         * Get the vector3 of the tile under the mouse
         */
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return this.grid.WorldToCell(mouseWorldPos);
    }

    TileBase GetTileBaseUnderMouse()
    {
        Vector3Int tileXYZ = GetTileUnderMouse_XYZ();
        return this.tileMap.GetTile(tileXYZ);
    }
}
