using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsForms_Exam_1
{
    public partial class Form1 : Form
    {
        static int numbers = default;
        MouseEventArgs cord;
        public Form1()
        {
            InitializeComponent();

            MouseDown += Form1_MouseDown;
            MouseUp += Form1_MouseUp;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            cord = e;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            int X = default;
            int Y = default;
            numbers++;
            Label label = new Label();
            this.Controls.Add(label);
            label.Text = numbers.ToString();
            label.TextAlign = ContentAlignment.TopCenter;
            label.AutoSize = false;

            if (cord.Location.X < e.Location.X && cord.Location.Y < e.Location.Y)
            {
                label.Location = cord.Location;
                X = e.Location.X - cord.Location.X;
                Y = e.Location.Y - cord.Location.Y;
                label.Size = new Size(X, Y);
            }
            else if (cord.Location.X > e.Location.X && cord.Location.Y > e.Location.Y)
            {
                label.Location = e.Location;
                X = cord.Location.X - e.Location.X;
                Y = cord.Location.Y - e.Location.Y;
                label.Size = new Size(X, Y);
            }
            else if (cord.Location.X < e.Location.X && cord.Location.Y > e.Location.Y)
            {
                label.Location = new Point(cord.X, e.Y);
                X = e.Location.X - cord.Location.X;
                Y = cord.Location.Y - e.Location.Y;
                label.Size = new Size(X, Y);
            }
            else if (cord.Location.X > e.Location.X && cord.Location.Y < e.Location.Y)
            {
                label.Location = new Point(e.X, cord.Y);
                X = cord.Location.X - e.Location.X;
                Y = e.Location.Y - cord.Location.Y;
                label.Size = new Size(X, Y);
            }

            Random rand = new Random();
            label.BackColor = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
            this.Controls.Add(label);
        }
    }
}
