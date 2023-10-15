using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public List<Line> hallways { get; set; } = new List<Line>();
    public List<Square> rooms { get; set; } = new List<Square>();

    public Map() { }

    public Map(List<Line> hallways_, List<Square> rooms_)
    {
        hallways = hallways_;
        rooms = rooms_;
    }
}
