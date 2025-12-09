using AlgoritmoDibujarLineas.Logica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace AlgoritmoDibujarLineas.View
{
    public partial class Circle : Form
    {
        private MidpointCircleController controller;
        private List<Point> puntos = new List<Point>();

        // Variables para la Animación, Estado y Límites del Zoom
        private int currentPointIndex = 0;
        private int centerX = 0;
        private int centerY = 0;
        private int minBmpX = 0;
        private int maxBmpX = 0;
        private int minBmpY = 0;
        private int maxBmpY = 0;

        // **1. Instancia del LineGraphicsHandler (para Cuadrícula y Zoom)**
        private readonly LineGraphicsHandler _graphicsHandler;

        // **NOTA:** Asumiendo que 'animationTimer' está declarado en el diseñador.

        public Circle()
        {
            InitializeComponent();
            controller = new MidpointCircleController();

            // **Inicialización de la instancia de LineGraphicsHandler**
            _graphicsHandler = new LineGraphicsHandler();

            btnGraficar.Click += BtnGraficar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            panelCanvas.Paint += PanelCanvas_Paint;

            // Configurar el Timer para la animación
            animationTimer.Interval = 250;
            animationTimer.Tick += AnimationTimer_Tick;

            panelCanvas.BackColor = Color.White;
        }

        // --- Método del Timer (Manejo de animación y historial) ---
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (currentPointIndex < puntos.Count)
            {
                currentPointIndex++;

                if (currentPointIndex > 0)
                {
                    Point p = puntos[currentPointIndex - 1];
                    int userX = p.X - centerX;
                    int userY = centerY - p.Y;

                    lblCurrentPoint.Text = $"Punto actual (BMP): ({p.X}, {p.Y})" +
                                           $"\nPunto (Cartesiano): ({userX}, {userY})";

                    string historyEntry = $"{currentPointIndex:00}. (X:{userX}, Y:{userY}) [BMP: {p.X}, {p.Y}]";
                    // Asegúrate de que txtPointsHistory sea un TextBox
                    txtPointsHistory.AppendText(historyEntry + Environment.NewLine);

                    txtPointsHistory.SelectionStart = txtPointsHistory.Text.Length;
                    txtPointsHistory.ScrollToCaret();
                }

                // Forzar Redibujado
                panelCanvas.Invalidate();
            }
            else
            {
                animationTimer.Stop();
                lblCurrentPoint.Text += "\n¡Dibujo finalizado!";
            }
        }

        private void BtnGraficar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtRadio.Text, out int r) || r <= 0)
                {
                    MessageBox.Show("Ingrese un valor numérico válido y positivo para el radio.");
                    return;
                }

                // 1. Limpiar y Resetear la Animación/Historial
                puntos.Clear();
                currentPointIndex = 0;
                animationTimer.Stop();
                lblCurrentPoint.Text = "Calculando círculo...";
                txtPointsHistory.Clear();

                centerX = panelCanvas.Width / 2;
                centerY = panelCanvas.Height / 2;

                int maxRadius = Math.Min(centerX, centerY);
                if (r >= maxRadius)
                {
                    MessageBox.Show($"El radio máximo permitido es {maxRadius - 5}.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    r = maxRadius - 5;
                }

                // 2. Obtener los puntos del controlador
                puntos = controller.CalcularCircunferencia(centerX, centerY, r);

                // **3. Calcular los límites para el ZOOM AUTOMÁTICO (USANDO LOS PUNTOS DEL CÍRCULO)**
                if (puntos.Any())
                {
                    minBmpX = puntos.Min(p => p.X);
                    maxBmpX = puntos.Max(p => p.X);
                    minBmpY = puntos.Min(p => p.Y);
                    maxBmpY = puntos.Max(p => p.Y);
                }
                else
                {
                    minBmpX = maxBmpX = minBmpY = maxBmpY = 0;
                }

                // 4. Iniciar la animación
                animationTimer.Start();
            }
            catch
            {
                MessageBox.Show("Ocurrió un error al procesar la entrada.");
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            animationTimer.Stop();
            currentPointIndex = 0;
            lblCurrentPoint.Text = "Esperando entrada...";
            txtPointsHistory.Clear();

            // Resetear límites para el zoom
            minBmpX = maxBmpX = minBmpY = maxBmpY = 0;

            puntos.Clear();
            panelCanvas.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // (Se mantiene)
        }

        // --- Evento de Pintado: Llama al manejador de gráficos ---
        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int width = panelCanvas.Width;
            int height = panelCanvas.Height;

            // **1. Pasar los datos de los puntos, el índice de la animación y los límites del zoom**
            _graphicsHandler.UpdateLineData(
                puntos,           // Se pasan los puntos del círculo
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