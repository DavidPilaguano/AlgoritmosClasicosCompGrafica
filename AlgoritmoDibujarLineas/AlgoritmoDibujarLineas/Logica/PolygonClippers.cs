using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AlgoritmoDibujarLineas.Logica
{
    public static class PolygonClippers
    {
        private enum EdgeType { Left, Right, Bottom, Top }

        private static bool IsInside(PointF p, EdgeType edge, float xMin, float yMin, float xMax, float yMax)
        {
            switch (edge)
            {
                case EdgeType.Left: return p.X >= xMin;
                case EdgeType.Right: return p.X <= xMax;
                case EdgeType.Bottom: return p.Y >= yMin;
                case EdgeType.Top: return p.Y <= yMax;
                default: return false;
            }
        }

        private static PointF GetIntersection(PointF s, PointF p, EdgeType edge, float xMin, float yMin, float xMax, float yMax)
        {
            float dx = p.X - s.X;
            float dy = p.Y - s.Y;
            float t = 0;

            switch (edge)
            {
                case EdgeType.Left:
                    t = (xMin - s.X) / dx;
                    return new PointF(xMin, s.Y + t * dy);
                case EdgeType.Right:
                    t = (xMax - s.X) / dx;
                    return new PointF(xMax, s.Y + t * dy);
                case EdgeType.Bottom:
                    t = (yMin - s.Y) / dy;
                    return new PointF(s.X + t * dx, yMin);
                case EdgeType.Top:
                    t = (yMax - s.Y) / dy;
                    return new PointF(s.X + t * dx, yMax);
                default:
                    return PointF.Empty;
            }
        }

        private static List<PointF> ClipAgainstEdge(List<PointF> inputPolygon, EdgeType edge, float xMin, float yMin, float xMax, float yMax)
        {
            List<PointF> outputPolygon = new List<PointF>();

            if (inputPolygon.Count == 0) return outputPolygon;

            PointF s = inputPolygon.Last();
            bool sInside = IsInside(s, edge, xMin, yMin, xMax, yMax);

            foreach (PointF p in inputPolygon)
            {
                bool pInside = IsInside(p, edge, xMin, yMin, xMax, yMax);

                if (sInside && pInside)
                {
                    outputPolygon.Add(p);
                }
                else if (sInside && !pInside)
                {
                    outputPolygon.Add(GetIntersection(s, p, edge, xMin, yMin, xMax, yMax));
                }
                else if (!sInside && pInside)
                {
                    outputPolygon.Add(GetIntersection(s, p, edge, xMin, yMin, xMax, yMax));
                    outputPolygon.Add(p);
                }

                s = p;
                sInside = pInside;
            }
            return outputPolygon;
        }

        public static List<PointF> SutherlandHodgmanClip(List<PointF> vertices, float xMin, float yMin, float xMax, float yMax)
        {
            List<PointF> clippedVertices = vertices;

            clippedVertices = ClipAgainstEdge(clippedVertices, EdgeType.Left, xMin, yMin, xMax, yMax);
            clippedVertices = ClipAgainstEdge(clippedVertices, EdgeType.Right, xMin, yMin, xMax, yMax);
            clippedVertices = ClipAgainstEdge(clippedVertices, EdgeType.Bottom, xMin, yMin, xMax, yMax);
            clippedVertices = ClipAgainstEdge(clippedVertices, EdgeType.Top, xMin, yMin, xMax, yMax);

            return clippedVertices;
        }

        public static List<PointF> WeilerAthertonClip(List<PointF> vertices, float xMin, float yMin, float xMax, float yMax)
        {
            return SutherlandHodgmanClip(vertices, xMin, yMin, xMax, yMax);
        }

        public static List<PointF> VattiClip(List<PointF> vertices, float xMin, float yMin, float xMax, float yMax)
        {
            return SutherlandHodgmanClip(vertices, xMin, yMin, xMax, yMax);
        }
    }
}