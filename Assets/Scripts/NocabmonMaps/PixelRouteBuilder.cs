using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class RandomDirections
{
    List<HashablePointInt> remainingDirections = new List<HashablePointInt>(
        NocabmonMapDirections.CARDINAL_DIRECTIONS
    );
    protected NocabRNG rng;

    public RandomDirections(NocabRNG rng_)
    {
        rng = rng_;
    }

    public bool isEmpty()
    {
        return remainingDirections.Count == 0;
    }

    public int remainingDirectionsCount()
    {
        return remainingDirections.Count;
    }

    public HashablePointInt getDirection()
    {
        if (this.isEmpty())
        {
            Debug.Log("Random directions has run out of items. Refreshing the directions");
            remainingDirections = new List<HashablePointInt>(
                NocabmonMapDirections.CARDINAL_DIRECTIONS
            );
        }

        int targetIndex = rng.randomIndex(remainingDirections);
        HashablePointInt result = remainingDirections[targetIndex];
        remainingDirections.RemoveAt(targetIndex);
        return result;
    }
}

public class PixelRouteBuilder : MonoBehaviour
{
    public void blab()
    {
        int width = 3;
        int height = 4;
        Box boundingBox = new Box(new Vector3Int(0, height), width, height);

        HashablePointInt start = new HashablePointInt(0, 0);
        HashablePointInt end = new HashablePointInt(0, height);

        // Start at the start point.
        // Generate a random direction (within the bounds of the box, not previously explored)
        // Apply that direction to current to get next
        // Add next to explored map
        // Add next to ordered list of points
        // Check if next == end  =>  end
        // If no neighbors remain
        //   pop the most recently added element from the ordered list of points
        //   Keep the popped point int he "explored" map
        //   the new tail becomes the current, generate new direction & continue

        NocabRNG rng = NocabRNG.newRNG;
        Stack<HashablePointInt> frontier = new Stack<HashablePointInt>();
        HashSet<HashablePointInt> explored = new HashSet<HashablePointInt>();
        List<HashablePointInt> orderList = new List<HashablePointInt>();

        frontier.Push(start);
        while (frontier.Count != 0)
        {
            // Find a new (unexplored) point
            HashablePointInt current = frontier.Pop();
            if (explored.Contains(current))
            {
                continue;
            }

            // mark current as explored
            explored.Add(current);
            orderList.Add(current);

            // Exit condition
            if (current == end)
            {
                break;
            }
            // Else not the end. Generate neighbors and loop
            Stack<HashablePointInt> neighbors = generateAllValidNeighbors(
                current,
                new RandomDirections(rng),
                boundingBox,
                explored
            );
            if (neighbors.Count == 0)
            {
                // No valid neighbors, we're in a corner
                // Back out to the previous point on the ordered list and start over
                orderList.RemoveAt(orderList.Count - 1);
                continue;
            }
            // Else, add the valid neighbors to the top of the stack
            foreach (var neighbor in neighbors)
            {
                // TODO: This will technically reverse the order of the neighbors into the frontier
                // but it should be _ok-ish_ because the neighbors are still first searched. This is
                // still a depth first search. Just the priority of which neighbors to explore provided
                // by the generateAllValidNeighbors function will be reversed.
                frontier.Push(neighbor);
            }
        }

        // TODO: Draw ordered list to map
    }

    public Stack<HashablePointInt> generateAllValidNeighbors(
        HashablePointInt current,
        RandomDirections directionGenerator,
        Box boundingBox,
        HashSet<HashablePointInt> explored
    )
    {
        // TODO Consider other direction generators?
        Stack<HashablePointInt> result = new();
        while (!directionGenerator.isEmpty())
        {
            HashablePointInt possibleNeighbor = current + directionGenerator.getDirection();
            if (explored.Contains(possibleNeighbor))
            {
                continue;
            }
            if (!boundingBox.ContainsPoint(new Vector3Int(possibleNeighbor.x, possibleNeighbor.y)))
            {
                continue;
            }
            result.Push(possibleNeighbor);
        }
        return result;
    }

    public EoR<Nothing, HashablePointInt> findValidNeighbor(
        HashablePointInt current,
        NocabRNG rng,
        Box boundingBox,
        HashSet<HashablePointInt> explored
    )
    {
        // TODO Consider removing this function
        RandomDirections directionGenerator = new(rng);
        while (!directionGenerator.isEmpty())
        {
            HashablePointInt possibleNeighbor = current + directionGenerator.getDirection();
            if (explored.Contains(possibleNeighbor))
            {
                continue;
            }
            if (!boundingBox.ContainsPoint(new Vector3Int(possibleNeighbor.x, possibleNeighbor.y)))
            {
                continue;
            }
            // Else the possible neighbor is good
            return new EoR<Nothing, HashablePointInt>(possibleNeighbor);
        }
        return new EoR<Nothing, HashablePointInt>(new Nothing());
    }
}; // public class PixelRouteBuilder
