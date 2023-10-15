using System.Collections.Generic;

public static class NocabmonMapDirections
{
    public static readonly HashablePointInt NORTH = new(0, 1);
    public static readonly HashablePointInt SOUTH = new(0, -1);
    public static readonly HashablePointInt EAST = new(1, 0);
    public static readonly HashablePointInt WEST = new(-1, 0);

    public static readonly HashSet<HashablePointInt> CARDINAL_DIRECTIONS =
        new HashSet<HashablePointInt> { NORTH, SOUTH, EAST, WEST };

    public static readonly HashablePointInt NORTH_EAST = new(1, 1);
    public static readonly HashablePointInt SOUTH_EAST = new(1, -1);
    public static readonly HashablePointInt SOUTH_WEST = new(1, -1);
    public static readonly HashablePointInt NORTH_WEST = new(-1, 1);
    public static readonly HashSet<HashablePointInt> ORDINAL_DIRECTIONS =
        new HashSet<HashablePointInt>
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
};

public class NocabmonMapContainer<TValue> : DictionaryCoords<TValue>
{
    public HashSet<TValue> getCardinalNeighbors(HashablePointInt targetCoord)
    {
        return getNeighbors_protected(targetCoord, NocabmonMapDirections.CARDINAL_DIRECTIONS);
    }

    public HashSet<TValue> getOrdinalNeighbors(HashablePointInt targetCoord)
    {
        return getNeighbors_protected(targetCoord, NocabmonMapDirections.ORDINAL_DIRECTIONS);
    }

    protected HashSet<TValue> getNeighbors_protected(
        HashablePointInt targetCoord,
        HashSet<HashablePointInt> neighborDirections
    )
    {
        HashSet<TValue> result = new HashSet<TValue>(4);
        foreach (HashablePointInt neighborDirection in neighborDirections)
        {
            HashablePointInt neighborCoord =
                new(
                    targetCoord.x + neighborDirection.x, //
                    targetCoord.y + neighborDirection.y
                );
            if (ContainsKey(neighborCoord))
            {
                result.Add(this[neighborCoord]);
            }
        }
        return result;
    }
}
