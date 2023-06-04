using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelShapeFactory {



    public static PixelStore square(Color c, int sideLength, Vector2Int topLeftCorner) {

        // TODO: Some level of optimization. I think each corner gets set twice. 
        PixelStore result = new PixelStore();

        // -1 because the corner point itself counts as one pixel of the total side length. 
        Vector2Int botRightCorner = 
            new Vector2Int(topLeftCorner.x + sideLength - 1, topLeftCorner.y + sideLength - 1);

        for(int delta = 0; delta < sideLength; delta++) {
            // Top horizontal
            result.SetPixel(topLeftCorner.x + delta, topLeftCorner.y, c);
            
            // Bot horizontal
            result.SetPixel(topLeftCorner.x + delta, botRightCorner.y, c);

            // Left Vertical
            result.SetPixel(topLeftCorner.x, topLeftCorner.y + delta, c);

            // Right Vertical
            result.SetPixel(botRightCorner.x, topLeftCorner.y + delta, c);
        }
        return result;
    }

    public static PixelStore connectPoints(List<Vector2Int> cornerPts, Color c) {
        /**
         * @brief Construct a Pixel Store that contains all the provided corner points,
         * AND all of the points in between. Effectively, the "pen" is put down at the
         * first point in the list, and a line is drawn towards the second point, then
         * the third and so on until all the points have been drawn.
         *
         * @param cornerPts, the keyframe points that the function will connect
         * @param c The color that this entire system structure is supposed to be.
         */
        
        if (cornerPts.Count <= 1) {
            // Invalid shape to draw
            return new PixelStore();
        }

        PixelStore result = new PixelStore();

        for (int bIndex = 1; bIndex < cornerPts.Count; bIndex ++) {
            // Pick two corner pts in provided shape
            Vector2Int ptA = cornerPts[bIndex - 1];
            Vector2Int ptB = cornerPts[bIndex];

            foreach(Vector2Int ptOnLineAB in BresenhamLineUtility.getLine_yield(ptA, ptB)) {
                // Calculate line between the two pts.
                // Each point is added to the PixelStore
                result.SetPixel(ptOnLineAB, c);
            }
        }

        return result;
    }

}
