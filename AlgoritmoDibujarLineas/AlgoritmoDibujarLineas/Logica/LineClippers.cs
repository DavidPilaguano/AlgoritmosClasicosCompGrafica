using System;
using System.Drawing;
using System.Linq;

// ** NAMESPACE CORREGIDO PARA EL PROYECTO EXISTENTE **
namespace AlgoritmoDibujarLineas.Logica
{
    // Estructura para el resultado del recorte
    public class ClippingResult
    {
        public bool IsVisible { get; set; }
        public PointF P1 { get; set; }
        public PointF P2 { get; set; }
    }

    // Códigos de región (Outcodes)
    [Flags]
    public enum OutCode : int
    {
        Inside = 0,
        Left = 1,
        Right = 2,
        Bottom = 4,
        Top = 8
    }

    public static class LineClippers
    {
        // --- 1. Método Auxiliar: Cálculo de OutCode ---

        private static OutCode ComputeOutCode(PointF p, float xMin, float yMin, float xMax, float yMax)
        {
            OutCode code = OutCode.Inside;

            if (p.X < xMin)
                code |= OutCode.Left;
            else if (p.X > xMax)
                code |= OutCode.Right;

            if (p.Y < yMin)
                code |= OutCode.Bottom;
            else if (p.Y > yMax)
                code |= OutCode.Top;

            return code;
        }

        // ------------------------------------------------------------------
        // --- 2. Algoritmo de Cohen-Sutherland ---
        // ------------------------------------------------------------------

        public static ClippingResult CohenSutherlandClip(PointF p1, PointF p2, float xMin, float yMin, float xMax, float yMax)
        {
            OutCode outcode1 = ComputeOutCode(p1, xMin, yMin, xMax, yMax);
            OutCode outcode2 = ComputeOutCode(p2, xMin, yMin, xMax, yMax);

            bool accept = false;

            while (true)
            {
                if ((outcode1 | outcode2) == OutCode.Inside) // Aceptación Trivial
                {
                    accept = true;
                    break;
                }
                else if ((outcode1 & outcode2) != OutCode.Inside) // Rechazo Trivial
                {
                    break;
                }
                else // Recorte
                {
                    OutCode outcodeOut = outcode1 != OutCode.Inside ? outcode1 : outcode2;
                    PointF p = new PointF();

                    float dx = p2.X - p1.X;
                    float dy = p2.Y - p1.Y;

                    if ((outcodeOut & OutCode.Top) != 0)
                    {
                        if (dy == 0) break;
                        p.X = p1.X + dx * (yMax - p1.Y) / dy;
                        p.Y = yMax;
                    }
                    else if ((outcodeOut & OutCode.Bottom) != 0)
                    {
                        if (dy == 0) break;
                        p.X = p1.X + dx * (yMin - p1.Y) / dy;
                        p.Y = yMin;
                    }
                    else if ((outcodeOut & OutCode.Right) != 0)
                    {
                        if (dx == 0) break;
                        p.Y = p1.Y + dy * (xMax - p1.X) / dx;
                        p.X = xMax;
                    }
                    else if ((outcodeOut & OutCode.Left) != 0)
                    {
                        if (dx == 0) break;
                        p.Y = p1.Y + dy * (xMin - p1.X) / dx;
                        p.X = xMin;
                    }

                    if (outcodeOut == outcode1)
                    {
                        p1 = p;
                        outcode1 = ComputeOutCode(p1, xMin, yMin, xMax, yMax);
                    }
                    else
                    {
                        p2 = p;
                        outcode2 = ComputeOutCode(p2, xMin, yMin, xMax, yMax);
                    }
                }
            }

            return new ClippingResult
            {
                IsVisible = accept,
                P1 = p1,
                P2 = p2
            };
        }

        // ------------------------------------------------------------------
        // --- 3. Algoritmo de Liang-Barsky ---
        // ------------------------------------------------------------------
            
        private static bool ClipTest(float p, float q, ref float t1, ref float t2)
        {
            float r;
            bool visible = true;

            if (p < 0.0) 
            {
                r = q / p;
                if (r > t2) visible = false;
                else if (r > t1) t1 = r;
            }
            else if (p > 0.0) 
            {
                r = q / p;
                if (r < t1) visible = false;
                else if (r < t2) t2 = r;
            }
            else if (q < 0.0) 
            {
                visible = false;
            }

            return visible;
        }

        public static ClippingResult LiangBarskyClip(PointF p1, PointF p2, float xMin, float yMin, float xMax, float yMax)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            float t1 = 0.0f;
            float t2 = 1.0f;

            if (!ClipTest(-dx, p1.X - xMin, ref t1, ref t2)) return new ClippingResult { IsVisible = false };
            if (!ClipTest(dx, xMax - p1.X, ref t1, ref t2)) return new ClippingResult { IsVisible = false };
            if (!ClipTest(-dy, p1.Y - yMin, ref t1, ref t2)) return new ClippingResult { IsVisible = false };
            if (!ClipTest(dy, yMax - p1.Y, ref t1, ref t2)) return new ClippingResult { IsVisible = false };

            if (t1 < t2)
            {
                PointF newP1 = new PointF(p1.X + t1 * dx, p1.Y + t1 * dy);
                PointF newP2 = new PointF(p1.X + t2 * dx, p1.Y + t2 * dy);

                return new ClippingResult
                {
                    IsVisible = true,
                    P1 = newP1,
                    P2 = newP2
                };
            }
            else
            {
                return new ClippingResult { IsVisible = false };
            }
        }

        public static ClippingResult NichollLeeNichollClip(PointF p1, PointF p2, float xMin, float yMin, float xMax, float yMax)
        {
            OutCode outcode1 = ComputeOutCode(p1, xMin, yMin, xMax, yMax);
            OutCode outcode2 = ComputeOutCode(p2, xMin, yMin, xMax, yMax);

            if ((outcode1 & outcode2) != OutCode.Inside)
                return new ClippingResult { IsVisible = false };

            if ((outcode1 | outcode2) == OutCode.Inside)
                return new ClippingResult { IsVisible = true, P1 = p1, P2 = p2 };

          
            return CohenSutherlandClip(p1, p2, xMin, yMin, xMax, yMax);
        }
    }
}