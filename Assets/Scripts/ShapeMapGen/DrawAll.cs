using UnityEngine.Tilemaps;

public class DrawAll 
{
    public Map map { get; set; }

    public DrawAll(Map map_)
    {
        map = map_;
    }

    public Tilemap drawToTileMap(Tilemap toDrawOn)
    {
        return DrawAll.drawToTileMap(toDrawOn, this.map);
    }

    public static Tilemap drawToTileMap(Tilemap toDrawOn, Map map)
    {
        // Draw the hallways first, then the rooms
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
