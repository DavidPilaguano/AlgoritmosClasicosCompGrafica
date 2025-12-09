using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
// Asegúrate de que esta referencia sea correcta para tu lógica de Bresenham
using AlgoritmoDibujarLineas.Logica;

namespace AlgoritmoDibujarLineas.view
{
    public partial class Bresenham_s_Line : Form
    {
        // Variables de Lógica
        private Bresenham_Controller bresenham = new Bresenham_Controller();

        // Variables de Datos y Control
        private List<Point> linePoints = new List<Point>();
        private int currentPointIndex = 0; // Índice para saber qué píxel dibujar

        // Almacenamiento de los límites reales de la línea en coordenadas de Bitmap
        private int minBmpX = 0;
        private int maxBmpX = 0;
        private int minBmpY = 0;
        private int maxBmpY = 0;

        // **Instancia de la clase modular de dibujo**
        private readonly LineGraphicsHandler _graphicsHandler;

        public Bresenham_s_Line()
        {
            InitializeComponent();

            // Inicialización del manejador de gráficos
            _graphicsHandler = new LineGraphicsHandler();

            pictureBox1.Paint += pictureBox1_Paint;

            // 1. Configurar el Timer (ejemplo: 500 ms = 0.5 segundos)
            animationTimer.Interval = 500;
            animationTimer.Tick += AnimationTimer_Tick;
        }

        private void Bresenham_s_Line_Load(object sender, EventArgs e)
        {
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (currentPointIndex < linePoints.Count)
            {
                // 1. Avanzar al siguiente punto
                currentPointIndex++;

                if (currentPointIndex > 0)
                {
                    Point p = linePoints[currentPointIndex - 1];

                    // --- Conversión a Coordenadas Cartesianas (Usuario) ---
                    int centerX = pictureBox1.Width / 2;
                    int centerY = pictureBox1.Height / 2;
                    int userX = p.X - centerX;
                    int userY = centerY - p.Y;

                    // --- 1. Actualizar la etiqueta del Punto Actual (si es un Label) ---
                    lblCurrentPoint.Text = $"Punto actual (BMP): ({p.X}, {p.Y})" +
                                           $"\nPunto (Cartesiano): ({userX}, {userY})";

                    // --- 2. Añadir al Historial (CORREGIDO) ---
                    string historyEntry = $"{currentPointIndex:00}. (X:{userX}, Y:{userY}) [BMP: {p.X}, {p.Y}]";

                    // Usar AppendText en el TextBox
                    txtPointsHistory.AppendText(historyEntry + Environment.NewLine);

                    // Opcional: Asegurar que el TextBox se desplace hacia abajo automáticamente
                    txtPointsHistory.SelectionStart = txtPointsHistory.Text.Length;
                    txtPointsHistory.ScrollToCaret();
                }

                // 3. Redibujar
                pictureBox1.Invalidate();
            }
            else
            {
                animationTimer.Stop();
                lblCurrentPoint.Text += "\n¡Dibujo finalizado!";
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Limpiar y resetear animación
                linePoints.Clear();
                currentPointIndex = 0;
                animationTimer.Stop();

                lblCurrentPoint.Text = "Calculando línea...";
                txtPointsHistory.Clear(); 

                // 2. Obtener coordenadas de usuario (asumiendo que txtX0, etc., existen)
                int user_x0 = int.Parse(txtX0.Text);
                int user_y0 = int.Parse(txtY0.Text);
                int user_x1 = int.Parse(txtX1.Text);
                int user_y1 = int.Parse(txtY1.Text);

                // 3. Mapeo a coordenadas de Bitmap (Origen: superior izquierda)
                int centerX = pictureBox1.Width / 2;
                int centerY = pictureBox1.Height / 2;

                int bmp_x0 = centerX + user_x0;
                int bmp_x1 = centerX + user_x1;
                // En coordenadas de pantalla Y positivo es hacia abajo, por eso restamos
                int bmp_y0 = centerY - user_y0;
                int bmp_y1 = centerY - user_y1;

                // 4. Obtener la secuencia completa de puntos
                linePoints = bresenham.CalculateLineBresenham(bmp_x0, bmp_y0, bmp_x1, bmp_y1);

                // 5. Calcular los límites para el ZOOM AUTOMÁTICO
                if (linePoints.Any())
                {
                    minBmpX = linePoints.Min(p => p.X);
                    maxBmpX = linePoints.Max(p => p.X);
                    minBmpY = linePoints.Min(p => p.Y);
                    maxBmpY = linePoints.Max(p => p.Y);
                }
                else
                {
                    // Resetear límites si no hay puntos
                    minBmpX = maxBmpX = minBmpY = maxBmpY = 0;
                }

                // 6. Iniciar la animación
                animationTimer.Start();
            }
            catch
            {
                MessageBox.Show("Entrada inválida. Por favor, ingrese solo números.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();
            linePoints.Clear();
            currentPointIndex = 0;

            // Resetear límites para el zoom
            minBmpX = maxBmpX = minBmpY = maxBmpY = 0;

            pictureBox1.Invalidate();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --- Evento de Pintado: Llama al manejador de gráficos ---
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // 1. Pasar los datos actuales a la clase manejadora
            _graphicsHandler.UpdateLineData(
                linePoints,
                currentPointIndex,
                minBmpX,
                maxBmpX,
                minBmpY,
                maxBmpY
            );

            // 2. Llamar al método Draw de la clase manejadora
            _graphicsHandler.Draw(e.Graphics, pictureBox1.Width, pictureBox1.Height);
        }
    }
}