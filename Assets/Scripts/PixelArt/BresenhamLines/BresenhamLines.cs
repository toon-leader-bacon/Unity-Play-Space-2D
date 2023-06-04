using System.Collections.Generic;
using UnityEngine;

public class BresenhamLineUtility {



    public static List<Vector2Int> getLine_list(Vector2Int start, Vector2Int end) {
        return new List<Vector2Int>(getLine_yield(start, end));
    }
    
    public static IEnumerable<Vector2Int> getLine_yield(Vector2Int start, Vector2Int end) {
        int deltaY = end.y - start.y;
        int deltaX = end.x - start.x;

        // Horizontal/ vertical lines
        if (deltaX == 0) {
            if (deltaY < 0) { return drawDownwardVerticalLine(start, deltaY * -1); }
            else            { return drawUpwardVerticalLine(start, deltaY); }
        }
        else if (deltaY == 0) {
            if (deltaX < 0) { return drawLeftwardHorizontalLine(start, deltaX * -1); }
            else            { return drawRightwardHorizontalLine(start, deltaX); }
        }

        // Sloped lines
        else if (Mathf.Abs(deltaY) < Mathf.Abs(deltaX))  {
            if (start.x > end.x) { return BresenhamLow(end, start); }
            else                 { return BresenhamLow(start, end); }
        } else {
            if (start.y > end.y) { return BresenhamHigh(end, start); }
            else                 { return BresenhamHigh(start, end); }
        }
    }


    // Bresenham's line alg taken from wikipedia https://en.wikipedia.org/wiki/Bresenham%27s_line_algorithm
    private static IEnumerable<Vector2Int> BresenhamLow(Vector2Int start, Vector2Int end) {
        int deltaX = end.x - start.x;
        int deltaY = end.y - start.y;
        int yDirection = 1;
        if (deltaY < 0) {
            yDirection = -1;
            deltaY *= -1;
        }
        float error = (2 * deltaY) - deltaX;

        int y = start.y;
        for (int x = start.x; x <= end.x; x++) {
            yield return new Vector2Int(x, y);
            // t.SetPixel(x, y, c);
            if (error > 0) {
                y += yDirection;
                error -= (2 * deltaX);
            }
            error += (2 * deltaY);
        }
    }

    private static IEnumerable<Vector2Int> BresenhamHigh(Vector2Int start, Vector2Int end) {
        int deltaX = end.x - start.x;
        int deltaY = end.y - start.y;
        int xDirection = 1;
        if (deltaX < 0) {
            xDirection = -1;
            deltaX *= -1;
        }
        float error = (2 * deltaX) - deltaY;

        int x = start.x;
        for (int y = start.y; y <= end.y; y++) {
            yield return new Vector2Int(x, y);
            if (error > 0) {
                x += xDirection;
                error -= (2 * deltaY);
            }
            error += (2 * deltaX);
        }
    }

    public static IEnumerable<Vector2Int> drawUpwardVerticalLine(Vector2Int start, int length) {
        length = Mathf.Abs(length);
        for (int i = 0; i < length; i++) { yield return new Vector2Int(start.x, start.y + i); }
    }

    public static IEnumerable<Vector2Int> drawDownwardVerticalLine(Vector2Int start, int length) {
        length = Mathf.Abs(length);
        for (int i = 0; i < length; i++) { yield return new Vector2Int(start.x, start.y - i); }
    }

    public static IEnumerable<Vector2Int> drawRightwardHorizontalLine(Vector2Int start, int length) {
        length = Mathf.Abs(length);
        for (int i = 0; i < length; i++) { yield return new Vector2Int(start.x + i, start.y); }
    }

    public static IEnumerable<Vector2Int> drawLeftwardHorizontalLine(Vector2Int start, int length) {
        length = Mathf.Abs(length);
        for (int i = 0; i < length; i++) { yield return new Vector2Int(start.x - i, start.y); }
    }

}
