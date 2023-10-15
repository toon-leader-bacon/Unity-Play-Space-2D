using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class BuildRectangleRoute1 : MonoBehaviour
{
    public Tile treeTile;
    public Tile backgroundTile;

    public Tilemap tm;

    public int width = 16;
    public int height = 32;

    public int xOffset = 10;

    void Start()
    {
        outlineWithTrees();
        InvokeRepeating(nameof(blab), 0, 1);
    }

    public void outlineWithTrees()
    {
        var mapContainer = new NocabmonMapContainer<NocabTile>();

        Vector3Int topLeftCorner = new Vector3Int(xOffset, height);
        Rectangle background = new Rectangle(topLeftCorner, width, height);
        background.tileType = backgroundTile;

        Box treeline = new Box(topLeftCorner, width, height);
        treeline.tileType = treeTile;

        background.drawToTileMap(tm);
        treeline.drawToTileMap(tm);
    }

    public void blab()
    {
        int edgeBuffer = 3;
        int holeSize = 2;

        int leftmostEdgeStart = xOffset + edgeBuffer;
        int rightmostEdgeStart = xOffset + width - edgeBuffer - holeSize;
        int middleEdgeStart = xOffset + (width / 2) - (holeSize / 2);

        int zoneStart = 2;
        int zoneHeight = 6;

        NocabRNG rng = NocabRNG.newRNG;
        int leftCenterRight = rng.randomIndex(3); // generate a random number in range [0, 3), ie either 0 1 or 2
        print(leftCenterRight);
        int startEdge;
        if (leftCenterRight == 0)
        {
            startEdge = leftmostEdgeStart;
        }
        else if (leftCenterRight == 1)
        {
            startEdge = middleEdgeStart;
        }
        else
        {
            startEdge = rightmostEdgeStart;
        }

        Line bottomBlocker = new Line(
            new Vector3Int(xOffset, zoneStart),
            new Vector3Int(xOffset + width, zoneStart)
        )
        {
            tileType = treeTile
        };
        Line topBlocker = new Line(
            new Vector3Int(xOffset, zoneStart + zoneHeight),
            new Vector3Int(xOffset + width, zoneStart + zoneHeight)
        )
        {
            tileType = treeTile
        };

        bottomBlocker.drawToTileMap(tm);
        topBlocker.drawToTileMap(tm);

        Line botEntrance = new Line(
            new Vector3Int(startEdge, zoneStart),
            new Vector3Int(startEdge + holeSize, zoneStart)
        )
        {
            tileType = backgroundTile
        };
        Line topEntrance = new Line(
            new Vector3Int(startEdge, zoneStart + zoneHeight),
            new Vector3Int(startEdge + holeSize, zoneStart + zoneHeight)
        )
        {
            tileType = backgroundTile
        };

        botEntrance.drawToTileMap(tm);
        topEntrance.drawToTileMap(tm);
    }
}
