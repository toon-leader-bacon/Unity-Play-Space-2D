using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Box : MonoBehaviour
{
    public Vector3Int topLeftCorner { get; set; } = new Vector3Int(0, 0, 0);
    public Vector3Int botRightCorner { get; set; } = new Vector3Int(0, 0, 0);

    public Tile tileType { get; set; }

    public int width
    {
        get { return Math.Abs(botRightCorner.x - topLeftCorner.x); }
    }

    public int height
    {
        get { return Math.Abs(topLeftCorner.y - botRightCorner.y); }
    }

    public Vector3Int topRightCorner
    {
        get
        {
            return new Vector3Int(
                botRightCorner.x, //
                topLeftCorner.y, //
                topLeftCorner.z
            );
        }
    }
    public Vector3Int botLeftCorner
    {
        get
        {
            return new Vector3Int(
                topLeftCorner.x, //
                botRightCorner.y, //
                topLeftCorner.z
            );
        }
    }

    public Box() { }

    public Box(Vector3Int topLeftCorner_, Vector3Int botRightCorner_)
    {
        topLeftCorner = topLeftCorner_;
        botRightCorner = botRightCorner_;
    }

    public Box(Vector3Int topLeftCorner_, int width, int height)
    {
        topLeftCorner = topLeftCorner_;
        botRightCorner = new Vector3Int(
            topLeftCorner_.x + width,
            topLeftCorner.y - height,
            topLeftCorner_.z
        );
    }

    public Tilemap drawToTileMap(Tilemap toDrawOn)
    {
        // TODO: Some level of optimization. I think each corner gets set twice.

        Line botLine = new Line(botLeftCorner, botRightCorner);
        botLine.tileType = this.tileType;
        Line topLine = new Line(topLeftCorner, topRightCorner);
        topLine.tileType = this.tileType;
        Line leftLine = new Line(topLeftCorner, botLeftCorner);
        leftLine.tileType = this.tileType;
        Line rightLine = new Line(topRightCorner, botRightCorner);
        rightLine.tileType = this.tileType;

        botLine.drawToTileMap(toDrawOn);
        topLine.drawToTileMap(toDrawOn);
        leftLine.drawToTileMap(toDrawOn);
        rightLine.drawToTileMap(toDrawOn);

        return toDrawOn;
    }
}; // public class Box
