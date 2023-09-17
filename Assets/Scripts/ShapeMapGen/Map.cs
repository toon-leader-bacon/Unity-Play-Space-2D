using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public ArrayList<Line> hallways { get; set; } = new ArrayList<Line>();
    public ArrayList<Square> rooms { get; set; } = new ArrayList<Square>();

    public Map() { }

    public Map(ArrayList<Line> hallways_, ArrayList<Square> rooms_)
    {
        hallways = hallways_;
        rooms = rooms_;
    }
}
