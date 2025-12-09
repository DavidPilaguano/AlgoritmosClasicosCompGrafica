using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; // Necesario para Min/Max
using System.Windows.Forms;
using AlgoritmoDibujarLineas.Logica;

namespace AlgoritmoDibujarLineas.view
{
    public partial class GCDDA : Form
    {
        // --- Variables de Lógica y Gráficos ---
        private DDA_Controller dda;

        // **Instancia del manejador de gráficos (Cuadrícula, Zoom, Dibujo)**
        private readonly LineGraphicsHandler _graphicsHandler;

        // --- Variables de Estado y Animación ---
        private List<Point> linePoints = new List<Point>();
        private int currentPointIndex = 0;
        private int centerX = 0; // Almacena el centro X del PictureBox
        private int centerY = 0; // Almacena el centro Y del PictureBox

        // --- Variables de Límites para el Zoom Automático ---
        private int minBmpX = 0;
        private int maxBmpX = 0;
        private int minBmpY = 0;
        private int maxBmpY = 0;

        // **NOTA:** Asumiendo que 'animationTimer' está declarado en el diseñador.

        public GCDDA()
        {
            InitializeComponent();
            dda = new DDA_Controller();

            // **Inicializar el manejador de gráficos**
            _graphicsHandler = new LineGraphicsHandler();

            // **Configurar el Timer para la animación**
            animationTimer.Interval = 100; // Velocidad de dibujo (ajustar si es necesario)
            animationTimer.Tick += AnimationTimer_Tick;

            // Asociar el evento Paint
            pictureBox1.Paint += PictureBox1_Paint;

            // Establecer el color de fondo (opcional)
            pictureBox1.BackColor = Color.White;
        }

        private void GCDDA_Load(object sender, EventArgs e)
        {
            
        }


        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (currentPointIndex < linePoints.Count)
            {
                currentPointIndex++;

                // Actualizar las etiquetas de estado (asumiendo lblCurrentPoint y txtPointsHistory existen)
                if (currentPointIndex > 0)
                {
                    Point p = linePoints[currentPointIndex - 1];
                    int userX = p.X - centerX;
                    int userY = centerY - p.Y;


                     lblCurrentPoint.Text = $"Punto actual (BMP): ({p.X}, {p.Y})" + 
                                           $"\nPunto (Cartesiano): ({userX}, {userY})";

                    // Añadir al Historial
                     string historyEntry = $"{currentPointIndex:00}. (X:{userX}, Y:{userY})";
                     txtPointsHistory.AppendText(historyEntry + Environment.NewLine);
                     txtPointsHistory.ScrollToCaret();
                }

                pictureBox1.Invalidate();
            }
            else
            {
                animationTimer.Stop();
                lblCurrentPoint.Text += "\n¡Dibujo finalizado!";
            }
        }


        // Funcion no utilizada
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }


        private void btnDraw_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Limpiar y Resetear la Animación/Historial
                linePoints.Clear();
                currentPointIndex = 0;
                animationTimer.Stop();
                // lblCurrentPoint.Text = "Calculando línea..."; 
                // txtPointsHistory.Clear();

                // 2. Obtener coordenadas de usuario y mapear
                int user_x0 = int.Parse(txtX0.Text);
                int user_y0 = int.Parse(txtY0.Text);
                int user_x1 = int.Parse(txtX1.Text);
                int user_y1 = int.Parse(txtY1.Text);

                centerX = pictureBox1.Width / 2;
                centerY = pictureBox1.Height / 2;

                int bmp_x0 = centerX + user_x0;
                int bmp_x1 = centerX + user_x1;
                int bmp_y0 = centerY - user_y0;
                int bmp_y1 = centerY - user_y1;


                linePoints = dda.CalculateLineDDA(bmp_x0, bmp_y0, bmp_x1, bmp_y1);

                // 4. Calcular los límites para el ZOOM AUTOMÁTICO
                if (linePoints.Any())
                {
                    minBmpX = linePoints.Min(p => p.X);
                    maxBmpX = linePoints.Max(p => p.X);
                    minBmpY = linePoints.Min(p => p.Y);
                    maxBmpY = linePoints.Max(p => p.Y);
                }
                else
                {
                    minBmpX = maxBmpX = minBmpY = maxBmpY = 0;
                }

                // 5. Iniciar la animación
                animationTimer.Start();
            }
            catch
            {
                MessageBox.Show("Entrada inválida. Por favor, ingrese solo números y verifique el controlador DDA.", "Error de entrada");
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
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

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            // 1. Pasar los datos de la línea, el índice de la animación y los límites del zoom
            _graphicsHandler.UpdateLineData(
                linePoints,
                currentPointIndex,
                minBmpX,
                maxBmpX,
                minBmpY,
                maxBmpY
            );

           
            _graphicsHandler.Draw(g, width, height);
        }
    }
}