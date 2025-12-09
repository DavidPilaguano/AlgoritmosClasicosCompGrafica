using AlgoritmoDibujarLineas.Logica;

using System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AlgoritmoDibujarLineas.Logica; // Asegúrate de que esta referencia sea correcta

namespace AlgoritmoDibujarLineas.View
{
    public partial class bresenhamsCircleGenerationAlgorithm : Form
    {
        private List<Point> circlePoints = new List<Point>();
        private int currentPointIndex = 0; // Para la animación
        private int centerX = 0; // Almacena el centro X para la conversión cartesiana
        private int centerY = 0; // Almacena el centro Y para la conversión cartesiana

        // Aunque es un círculo, usaremos un manejador de gráficos simple para la cuadrícula
        // Nota: Si quieres el zoom automático como en la línea, usa LineGraphicsHandler.
        // Si quieres solo cuadrícula, usa el CircleGraphicsHandler simple que definimos antes.
        // Por simplicidad en la animación, usaré una clase genérica llamada GraphicsHandler.
        private readonly LineGraphicsHandler _graphicsHandler;

        // Almacenamiento de los límites reales para el zoom (como en la línea)
        private int minBmpX = 0;
        private int maxBmpX = 0;
        private int minBmpY = 0;
        private int maxBmpY = 0;


        public bresenhamsCircleGenerationAlgorithm()
        {
            InitializeComponent();

            // Inicialización del manejador de gráficos (usando el de la línea para el zoom)
            _graphicsHandler = new LineGraphicsHandler();

            this.drawingPanel.Paint += new PaintEventHandler(DrawingPanel_Paint);
            this.drawingPanel.BackColor = Color.White;

            // Configuración del Timer para la animación
            animationTimer.Interval = 250; // Velocidad de dibujo
            animationTimer.Tick += AnimationTimer_Tick;
        }

        // --- Evento de Timer para la animación ---
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (currentPointIndex < circlePoints.Count)
            {
                currentPointIndex++;

                if (currentPointIndex > 0)
                {
                    Point p = circlePoints[currentPointIndex - 1];

                    // --- Conversión a Coordenadas Cartesianas (Usuario) ---
                    // Usamos el centro que se calculó en drawButton_Click
                    int userX = p.X - centerX;
                    int userY = centerY - p.Y;

                    // --- 1. Actualizar la etiqueta del Punto Actual ---
                    lblCurrentPoint.Text = $"Punto actual (BMP): ({p.X}, {p.Y})" +
                                           $"\nPunto (Cartesiano): ({userX}, {userY})";

                    // --- 2. Añadir al Historial ---
                    string historyEntry = $"{currentPointIndex:00}. (X:{userX}, Y:{userY}) [BMP: {p.X}, {p.Y}]";
                    txtPointsHistory.AppendText(historyEntry + Environment.NewLine);

                    txtPointsHistory.SelectionStart = txtPointsHistory.Text.Length;
                    txtPointsHistory.ScrollToCaret();
                }

                // 3. Redibujar
                drawingPanel.Invalidate();
            }
            else
            {
                animationTimer.Stop();
                lblCurrentPoint.Text += "\n¡Dibujo finalizado!";
            }
        }

        // --- CONTROLADOR: Método que genera los datos al hacer click ---
        private void drawButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRadio.Text, out int radius) || radius <= 0)
            {
                MessageBox.Show("Por favor, introduce un valor de radio entero positivo válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Limpiar y resetear animación
            circlePoints.Clear();
            currentPointIndex = 0;
            animationTimer.Stop();
            lblCurrentPoint.Text = "Calculando círculo...";
            txtPointsHistory.Clear();

            // 2. Definir el centro (coordenadas de Bitmap)
            centerX = drawingPanel.Width / 2;
            centerY = drawingPanel.Height / 2;

            // 3. Validación de radio 
            int maxRadius = Math.Min(centerX, centerY);
            if (radius >= maxRadius)
            {
                MessageBox.Show($"El radio máximo permitido es {maxRadius - 5} para que el círculo sea visible.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                radius = maxRadius - 5;
                txtRadio.Text = radius.ToString();
            }

            // 4. Llamar al Modelo (Algoritmo)
            circlePoints = BresenhamCircleAlgorithm.GenerateCirclePoints(centerX, centerY, radius);

            // 5. Calcular los límites para el ZOOM AUTOMÁTICO (similar al de la línea)
            if (circlePoints.Any())
            {
                minBmpX = circlePoints.Min(p => p.X);
                maxBmpX = circlePoints.Max(p => p.X);
                minBmpY = circlePoints.Min(p => p.Y);
                maxBmpY = circlePoints.Max(p => p.Y);
            }
            else
            {
                minBmpX = maxBmpX = minBmpY = maxBmpY = 0;
            }

            // 6. Iniciar la animación
            animationTimer.Start();
        }

        // --- VISTA/DIBUJO: Evento Paint ---
        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            // 1. Pasar los datos actuales a la clase manejadora
            _graphicsHandler.UpdateLineData(
                circlePoints, // Se usa el método UpdateLineData para pasar la lista de puntos
                currentPointIndex,
                minBmpX,
                maxBmpX,
                minBmpY,
                maxBmpY
            );

            // 2. Llamar al método Draw de la clase manejadora
            // La clase LineGraphicsHandler dibujará los puntos del círculo como píxeles,
            // y manejará el zoom/cuadrícula automáticamente.
            _graphicsHandler.Draw(e.Graphics, drawingPanel.Width, drawingPanel.Height);
        }

        // --- Otros botones de control ---
        private void btnClear_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();
            circlePoints.Clear();
            currentPointIndex = 0;

            // Resetear límites para el zoom y limpieza de labels
            minBmpX = maxBmpX = minBmpY = maxBmpY = 0;
            lblCurrentPoint.Text = "Esperando entrada...";
            txtPointsHistory.Clear();

            drawingPanel.Invalidate();
        }

        // ... (otros métodos como btnBack_Click) ...
    }
}