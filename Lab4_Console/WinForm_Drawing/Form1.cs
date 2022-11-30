using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_Drawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MyPen = new Pen(Color.FromArgb(255, 0, 0));
        }

        //Режим ресивоная области on\off
        private bool IsDrawingMode = false;

        //Чем заполняем область
        private Pen MyPen { get; set; }

        //Список точек-границ области
        private List<BorderPoint> BorderPixels;
        //Устанавливаем изображения для PictureBox

        private void Button1_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(@"E:\тест.jpg");
            pictureBox1.Image = img;
        }
        //Включаем режим рисования и обнуляем список граничных точек
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsDrawingMode = true;
            BorderPixels = new List<BorderPoint>();
        }

        //Выкл. режим рисования
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsDrawingMode = false;
        }

        //Рисум область
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsDrawingMode && pictureBox1.Image != null)
            {
                _ = pictureBox1.CreateGraphics();

                //Рисуем точку границы
                pictureBox1.CreateGraphics().DrawRectangle(MyPen, new Rectangle(e.X, e.Y, 1, 1));

                //Добавляем точку в список границ
                var bp = new BorderPoint
                {
                    Point = new Point(e.X, e.Y),
                    Type = (byte)PathPointType.Line
                };
                BorderPixels.Add(bp);
            }
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
            //Конструируем объект GrapihicsPath для нарисованной области
            var types = BorderPixels.Select(p => p.Type).ToArray();
            var points = BorderPixels.Select(p => p.Point).ToArray();
            GraphicsPath path = new GraphicsPath(points, types);

            //Заполняем GraphicsPath цветом
            var g = pictureBox1.CreateGraphics();
            Region rg = new Region(path);
            g.FillPath(Brushes.Black, path);
        }
    }
}