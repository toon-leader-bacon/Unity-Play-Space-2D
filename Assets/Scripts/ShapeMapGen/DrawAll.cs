using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition.ReflectionModel;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawAll : MonoBehaviour
{
    public Map map { get; set; }

    DrawAll(Map map_)
    {
        map = map_;
    }

    public Tilemap drawToTileMap(Tilemap toDrawOn)
    {
        return DrawAll.drawToTileMap(toDrawOn, this.map);
    }

    public static Tilemap drawToTileMap(Tilemap toDrawOn, Map map)
    {
        foreach (var hall in map.hallways)
        {
            hall.drawToTileMap(toDrawOn);
        }
        foreach (var room in map.rooms)
        {
            room.drawToTileMap(toDrawOn);
        }
        return toDrawOn;
    }
}
