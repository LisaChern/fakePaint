using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fakePaint
{
    public partial class Form1 : Form
    {
        Bitmap pic; //координаты для рисования кистью
        Bitmap pic1; //второй слой
        string mode;
        int x1, y1;
        int xclick1, yclick1;
        public Form1()
        {
            mode = "Линия";
            InitializeComponent();
            pic = new Bitmap(1000, 1000);
            pic1 = new Bitmap(1000, 1000);
            SolidBrush b = new SolidBrush(Color.White);
            Graphics.FromImage(pic).FillRectangle(b, 0, 0 , pic.Width, pic.Height);
            Graphics.FromImage(pic1).FillRectangle(b, 0, 0, pic1.Width, pic1.Height);
            x1 = y1 = 0;
            pictureBox1.Image = pic;

        }

        private void button28_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click_1(object sender, EventArgs e) //кнопки выбора цвета
        {
            Button b = (Button)sender;
            button1.BackColor = b.BackColor;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)  //сохрание файла изображения
        {
            saveFileDialog1.ShowDialog();
            if(saveFileDialog1.FileName!=" ")
            pic.Save(saveFileDialog1.FileName);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) //открытия файла с изображением
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != " ") 
            {
                pic = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = pic;
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            mode = "Линия";
        }

        private void button39_Click(object sender, EventArgs e)
        {
            mode = "Прямоугольник";
        }

        private void button41_Click(object sender, EventArgs e)
        {
            mode = "Овал";
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Pen p;
            p = new Pen(button1.BackColor, trackBar1.Value);
            Graphics g;
            g = Graphics.FromImage(pic);
            if (mode == "Прямоугольник")
            {
                g.DrawRectangle(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1);
            }
            
            if (mode == "Овал")
            {
                g.DrawEllipse(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1);
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            xclick1=e.X;
            yclick1=e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) //создание кисти
        {   
            Pen p;
            p = new Pen(button1.BackColor, trackBar1.Value);
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Graphics g;
            g = Graphics.FromImage(pic);

            Graphics g1;
            g1 = Graphics.FromImage(pic1);
            if (e.Button == MouseButtons.Left)
            {
                if (mode == "Линия")
                {
                    g.DrawLine(p, x1, y1, e.X, e.Y);
                }
                if (mode == "Прямоугольник")
                {
                    g1.Clear(Color.White);
                    g1.DrawRectangle(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1);
                }
                if (mode == "Овал")
                {
                    g1.Clear(Color.White);
                    g1.DrawEllipse(p, xclick1, yclick1, e.X - xclick1, e.Y - yclick1);
                }
                g1.DrawImage(pic, 0, 0);

                    pictureBox1.Image = pic1;

            }

            x1 = e.X;
            y1 = e.Y;
        }
    }
}
