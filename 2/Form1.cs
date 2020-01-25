using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            int maxRange = 700;
            Random random = new Random();
            Direction direction = (Direction)random.Next(0, 3);
            Point point = new Point(label.Location.X, label.Location.Y);
            int range = random.Next(250, maxRange);

            switch (direction)
            {
                case Direction.Up:
                    for (; point.Y > range; point.Y--)
                    {
                        if (point.Y <= 15)
                            goto case Direction.Down;
                        label.Location = point;
                    }
                    break;
                case Direction.Down:
                    for (; point.Y < range; point.Y++)
                    {
                        if (point.Y >= 500)
                            goto case Direction.Up;
                        label.Location = point;
                    }
                    break;
                case Direction.Left:
                    for (; point.X > range; point.X--)
                    {
                        if (point.X <= 15)
                            goto case Direction.Right;
                        label.Location = point;
                    }
                    break;
                case Direction.Right:
                    if (point.X >= 500)
                        goto case Direction.Left;
                    for (; point.X < range; point.X++)
                    {
                        label.Location = point;
                    }
                    break;
            }
        }
    }
}
