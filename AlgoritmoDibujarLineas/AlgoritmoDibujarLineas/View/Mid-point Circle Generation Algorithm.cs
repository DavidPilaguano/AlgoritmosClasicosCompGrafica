using AlgoritmoDibujarLineas.Logica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; // Necesario para Linq (Min/Max)
using System.Windows.Forms;

namespace AlgoritmoDibujarLineas.View
{
    public partial class Mid_point_Circle_Generation_Algorithm : Form
    {
        // 1. ESTADO: Almacena los puntos generados por el Modelo.
        private List<Point> circlePoints = new List<Point>();

        // --- Variables de Estado y Animación ---
        private int currentPointIndex = 0;
        private int centerX = 0;
        private int centerY = 0;

        // --- Variables de Límites para el Zoom Automático ---
        private int minBmpX = 0;
        private int maxBmpX = 0;
        private int minBmpY = 0;
        private int maxBmpY = 0;

        // **Instancia del LineGraphicsHandler (para Cuadrícula, Zoom y Dibujo)**
        private readonly LineGraphicsHandler _graphicsHandler;


        public Mid_point_Circle_Generation_Algorithm()
        {
            InitializeComponent();

            // **Inicialización del manejador de gráficos**
            _graphicsHandler = new LineGraphicsHandler();

            // **Configurar el Timer para la animación**
            // NOTA: Asume que 'animationTimer' está declarado en el diseñador
            animationTimer.Interval = 100; // Velocidad de dibujo (ajustar)
            animationTimer.Tick += AnimationTimer_Tick;
        }

        // --- Manejador del Temporizador para la animación ---
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (currentPointIndex < circlePoints.Count)
            {
                currentPointIndex++;

                if (currentPointIndex > 0)
                {
                    Point p = circlePoints[currentPointIndex - 1];

                    // Transformar coordenadas BMP a Cartesiano (X=0, Y=0 en el centro del panel)
                    int userX = p.X - centerX;
                    int userY = centerY - p.Y;

                    // Actualización de Etiquetas (Asume que existen lblCurrentPoint y txtPointsHistory)
                    lblCurrentPoint.Text = $"Punto actual (BMP): ({p.X}, {p.Y})" +
                                           $"\nPunto (Cartesiano): ({userX}, {userY})";
                    string historyEntry = $"{currentPointIndex:00}. (X:{userX}, Y:{userY}) [BMP: {p.X}, {p.Y}]";
                    txtPointsHistory.AppendText(historyEntry + Environment.NewLine);
                    txtPointsHistory.ScrollToCaret();
                }

                // **Se llama Invalidate al control de dibujo para repintar.**
                drawingPanel.Invalidate();
            }
            else
            {
                animationTimer.Stop();
                lblCurrentPoint.Text += "\n¡Dibujo finalizado!";
            }
        }

         private void drawButton_Click(object sender, EventArgs e)
        {
            // Validar la entrada del radio (asume txtRadio)
            if (!int.TryParse(txtRadio.Text, out int radius) || radius <= 0)
            {
                MessageBox.Show("Por favor, introduce un valor de radio entero positivo válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Resetear el estado de la animación
            circlePoints.Clear();
            currentPointIndex = 0;
            animationTimer.Stop();

            lblCurrentPoint.Text = "Calculando círculo...";
            txtPointsHistory.Clear();

            // 2. Obtener el centro del área de dibujo y guardar
            centerX = drawingPanel.Width / 2;
            centerY = drawingPanel.Height / 2;

            // 3. LLAMAR AL MODELO
            circlePoints = MidpointCircleAlgorithm.GenerateCirclePoints(centerX, centerY, radius);

            // 4. Calcular los límites para el ZOOM AUTOMÁTICO
            if (circlePoints.Any())
            {
                minBmpX = circlePoints.Min(p => p.X);
                maxBmpX = circlePoints.Max(p => p.X);
                minBmpY = circlePoints.Min(p => p.Y);
                maxBmpY = circlePoints.Max(p => p.Y);
            }
            else
            {
                // Si no hay puntos, usar el centro como límite para un zoom 1x
                minBmpX = maxBmpX = centerX;
                minBmpY = maxBmpY = centerY;
            }

            // 5. Iniciar la animación
            animationTimer.Start();
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Los valores de Width y Height provienen del control que se está pintando.
            int width = drawingPanel.Width;
            int height = drawingPanel.Height;

            // 1. Pasar los datos de los puntos, el índice de la animación y los límites del zoom
            _graphicsHandler.UpdateLineData(
                circlePoints,
                currentPointIndex,
                minBmpX,
                maxBmpX,
                minBmpY,
                maxBmpY
            );

            // 2. Llamar al método Draw del LineGraphicsHandler para dibujar todo
            _graphicsHandler.Draw(g, width, height);
        }

        // Método de carga vacío, solo para completar la estructura:
        private void Mid_point_Circle_Generation_Algorithm_Load(object sender, EventArgs e)
        {
            // No se requiere código de inicialización aquí.
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}