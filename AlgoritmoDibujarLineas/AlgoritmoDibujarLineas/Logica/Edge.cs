using System.Drawing;

namespace AlgoritmoDibujarLineas.Logica
{
    public class Edge
    {
        public int YMin { get; set; }
        public int YMax { get; set; }
        public float XofYMin { get; set; } 
        public float InverseSlope { get; set; } 

        public Edge(Point p1, Point p2)
        {
            if (p1.Y > p2.Y) (p1, p2) = (p2, p1);

            YMin = p1.Y;
            YMax = p2.Y;
            XofYMin = p1.X;

            if (p2.Y == p1.Y)
            {
                InverseSlope = 0.0f;
            }
            else
            {
                InverseSlope = (float)(p2.X - p1.X) / (p2.Y - p1.Y);
            }
        }
    }
}