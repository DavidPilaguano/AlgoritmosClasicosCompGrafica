using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AlgoritmoDibujarLineas.Logica
{
    public static class ScanLineFillAlgorithm
    {
       
        public static List<Point> Fill(List<Point> polygonVertices, Color fillColor, Bitmap canvas)
        {
            var filledPoints = new List<Point>();
            if (polygonVertices == null || polygonVertices.Count < 3 || canvas == null)
                return filledPoints;

            var edgeTable = BuildEdgeTable(polygonVertices);
            var activeEdgeList = new List<Edge>();

            int minY = polygonVertices.Min(p => p.Y);
            int maxY = polygonVertices.Max(p => p.Y);

            for (int y = minY; y <= maxY; y++)
            {
                // A. Añadir nuevas aristas
                if (edgeTable.ContainsKey(y))
                {
                    activeEdgeList.AddRange(edgeTable[y]);
                }

                // B. Limpiar y Ordenar AEL
                activeEdgeList.RemoveAll(e => e.YMax == y);
                activeEdgeList = activeEdgeList.OrderBy(e => e.XofYMin).ToList();

                // C. Rellenar los píxeles (Regla de Paridad)
                for (int i = 0; i < activeEdgeList.Count - 1; i += 2)
                {
                    // Aplicar REDONDEO para precisión en la intersección
                    int xStart = (int)Math.Round(activeEdgeList[i].XofYMin);
                    int xEnd = (int)Math.Round(activeEdgeList[i + 1].XofYMin);

                    for (int x = xStart; x < xEnd; x++)
                    {
                        if (x >= 0 && x < canvas.Width && y >= 0 && y < canvas.Height)
                        {
                            canvas.SetPixel(x, y, fillColor);
                            filledPoints.Add(new Point(x, y));
                        }
                    }
                }

                // D. Actualizar X de intersección para la *siguiente* línea (y+1)
                foreach (var edge in activeEdgeList)
                {
                    edge.XofYMin += edge.InverseSlope;
                }
            }
            return filledPoints; // Retorna todos los puntos
        }

        private static Dictionary<int, List<Edge>> BuildEdgeTable(List<Point> vertices)
        {
            var et = new Dictionary<int, List<Edge>>();
            int count = vertices.Count;

            for (int i = 0; i < count; i++)
            {
                Point p1 = vertices[i];
                Point p2 = vertices[(i + 1) % count];

                if (p1.Y != p2.Y)
                {
                    var edge = new Edge(p1, p2);
                    int ymin = edge.YMin;

                    if (!et.ContainsKey(ymin))
                    {
                        et[ymin] = new List<Edge>();
                    }
                    et[ymin].Add(edge);
                }
            }
            return et;
        }
    }
}