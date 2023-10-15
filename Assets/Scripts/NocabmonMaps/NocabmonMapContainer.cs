using System.Collections.Generic;

public class NocabmonMapContainer : Dictionary<HashableCoord, NocabTile>
{
    public static readonly HashableCoord NORTH = new HashableCoord(0, 1);
    public static readonly HashableCoord SOUTH = new HashableCoord(0, -1);
    public static readonly HashableCoord EAST = new HashableCoord(1, 0);
    public static readonly HashableCoord WEST = new HashableCoord(-1, 0);

    public static readonly HashSet<HashableCoord> CARDINAL_DIRECTIONS = new HashSet<HashableCoord>
    {
        NORTH,
        SOUTH,
        EAST,
        WEST
    };

    public static readonly HashableCoord NORTH_EAST = new HashableCoord(1, 1);
    public static readonly HashableCoord SOUTH_EAST = new HashableCoord(1, -1);
    public static readonly HashableCoord SOUTH_WEST = new HashableCoord(1, -1);
    public static readonly HashableCoord NORTH_WEST = new HashableCoord(-1, 1);
    public static readonly HashSet<HashableCoord> ORDINAL_DIRECTIONS = new HashSet<HashableCoord>
    {
        NORTH,
        NORTH_EAST,
        EAST,
        SOUTH_EAST,
        SOUTH,
        SOUTH_WEST,
        WEST,
        NORTH_WEST
    };

    public HashSet<NocabTile> getCardinalNeighbors(HashableCoord targetCoord)
    {
        return getNeighbors_protected(targetCoord, CARDINAL_DIRECTIONS);
    }

    public HashSet<NocabTile> getOrdinalNeighbors(HashableCoord targetCoord)
    {
        return getNeighbors_protected(targetCoord, ORDINAL_DIRECTIONS);
    }

    protected HashSet<NocabTile> getNeighbors_protected(
        HashableCoord targetCoord,
        HashSet<HashableCoord> neighborDirections
    )
    {
        HashSet<NocabTile> result = new HashSet<NocabTile>(4);
        foreach (HashableCoord neighborDirection in neighborDirections)
        {
            HashableCoord neighborCoord = new HashableCoord(
                targetCoord.coord.x + neighborDirection.coord.x, //
                targetCoord.coord.y + neighborDirection.coord.y
            );
            if (ContainsKey(neighborCoord))
            {
                result.Add(this[neighborCoord]);
            }
        }
        return result;
    }
}
