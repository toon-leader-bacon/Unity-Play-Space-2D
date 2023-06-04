using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PixelDrawer {

    // Notes on pixel art: https://blogs.unity3d.com/2015/06/19/pixel-perfect-2d/


    public static Sprite packTexture(Texture2D texture) {
        Rect rect = new Rect(0, 0, texture.width, texture.height);
        Vector2 piviot = new Vector2(0.5f, 0.5f);
        return Sprite.Create(texture, rect, piviot);
    }

    public static void drawOntoTexture(Texture2D tex, PixelStore toBeDrawn) {
        // Draws the pixels in the provided PixelStore on top of the provided texture
        foreach(KeyValuePair<Vector2Int, Color> kvp in toBeDrawn.pixels) {
            Vector2Int point = kvp.Key;
            tex.SetPixel(point.x, point.y, kvp.Value);
        }
    }

    #region Lines

    public static void DrawLine(Texture2D t, Vector2Int start, Vector2Int end, Color c) {
        foreach(Vector2Int pt in BresenhamLineUtility.getLine_yield(start, end)) {
            // Loop over every pt in the calculated line and color it on the texture
            t.SetPixel(pt.x, pt.y, c);
        }
    }

    #endregion

    #region Curves

    private static int radiusError(int x, int y, int r) { return(x*x) + (y*y) - (r*r); }
    private static int yChange(int y) { return (2 * y) + 1; }
    private static int xChange(int x) { return 1 - (2 * x); }
    public static void MidpointCircleAlgorithim(Texture2D t, Vector2Int center, int radius, Color c) {
        int xOffset = center.x;
        int yOffset = center.y;
        int x = radius;
        int y = 0;
        while (x >= y) {
            t.SetPixel(xOffset + x, yOffset + y, c);  // o1
            t.SetPixel(xOffset - x, yOffset + y, c);  // o4
            t.SetPixel(xOffset + x, yOffset - y, c);  // o8
            t.SetPixel(xOffset - x, yOffset - y, c);  // o5

            t.SetPixel(xOffset + y, yOffset + x, c);  // o2
            t.SetPixel(xOffset - y, yOffset + x, c);  // o3
            t.SetPixel(xOffset + y, yOffset - x, c);  // o7
            t.SetPixel(xOffset - y, yOffset - x, c);  // o6
            
            int decisionFactor = 2 * (radiusError(x, y, radius) + yChange(y)) + xChange(x);
            if (decisionFactor > 0) { x--; }
            //if (radiusError(x-1, y+1, radius) < radiusError(x, y+1, radius)) { x--; }
            y ++; // y always increases
        }

    }

    #endregion

    #region Errors/ Helpers/ Other

    private static void assertNonNegative(int n) {
        if (n < 0) { throw new System.ArgumentOutOfRangeException("length must be non negative: " + n); }
    }

    #endregion
}
