using System.Collections.Generic;

public class Map
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
