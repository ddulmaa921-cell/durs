using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
namespace durs
{
    public partial class Form1 : Form
    {
        private Bitmap canvas;
        private bool isDrawing = false;
        private Point lastPoint;
        private Color currentColor = Color.Black;
        private string currentTool = "pen";
        private int penWidth = 3;
        private Point startPoint;
        public Form1()
        {
            InitializeComponent();

            canvas = new Bitmap(
                pictureBox1.Width,
                pictureBox1.Height
            );

            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);
            }

            pictureBox1.Image = canvas;
            pictureBox1.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentTool = "eraser";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearCanvas();
        }

        // Зургийн талбарыг цэвэрлэх функц
        private void ClearCanvas()
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);
            }

            pictureBox1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing)
                return;

            isDrawing = false;

            using (Graphics g = Graphics.FromImage(canvas))
            using (Pen pen = new Pen(currentColor, penWidth))
            {
                int x = Math.Min(startPoint.X, e.X);
                int y = Math.Min(startPoint.Y, e.Y);
                int w = Math.Abs(e.X - startPoint.X);
                int h = Math.Abs(e.Y - startPoint.Y);

                if (currentTool == "circle")
                    g.DrawEllipse(pen, x, y, w, h);

                else if (currentTool == "rectangle")
                    g.DrawRectangle(pen, x, y, w, h);

                else if (currentTool == "triangle")
                {
                    Point[] points =
                    {
                new Point(x + w / 2, y),
                new Point(x, y + h),
                new Point(x + w, y + h)
            };

                    g.DrawPolygon(pen, points);
                }
            }

            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)

        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                lastPoint = e.Location;
                startPoint = e.Location;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing)
                return;

            if (currentTool == "pen" || currentTool == "eraser")
            {
                using (Graphics g = Graphics.FromImage(canvas))
                using (Pen pen = new Pen(
                    currentTool == "eraser" ? Color.White : currentColor,
                    currentTool == "eraser" ? 20 : penWidth))
                {
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                    g.DrawLine(pen, lastPoint, e.Location);
                }

                lastPoint = e.Location;
                pictureBox1.Invalidate();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentTool = "pen";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentTool = "circle";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            currentTool = "rectangle";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentTool = "triangle";
        }
        private void button10_Click(object sender, EventArgs e)
        {
            currentColor = Color.Fuchsia;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            currentColor = Color.White;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            currentColor = Color.Black;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            currentColor = Color.Red;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            currentColor = Color.Lime;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            currentColor = Color.Blue;
        }
    }
}
