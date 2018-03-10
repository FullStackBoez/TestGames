using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private bool up, down, left, right;
        private int x, y, speed = 5;
        private static int Wwidth,Wheight;
        private Player pl1, pl2;
        public Form1()
        {
            //FormBorderStyle = FormBorderStyle.None;
           // WindowState = FormWindowState.Maximized;
           
            InitializeComponent();
            Wwidth = Screen.PrimaryScreen.WorkingArea.Width;
            Wheight = Screen.PrimaryScreen.WorkingArea.Height;
            pl1 = new Player(Wwidth, Wheight);
            pl2 = new Player(Wwidth, Wheight);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (right && down)
            {
                y += speed;
                x += speed;
            }
            if (down && left)
            {
                y -= speed;
                x += speed;
            }
            if (up && right)
            {
                y += speed;
                x -= speed;
            }
            if (up && left)
            {
                y -= speed;
                x -= speed;
            }
            if (up)
                x -= speed;
            if (down)
                x += speed;
            if (left)
                y -= speed;
            if (right)
                y += speed;

            if (x < 0)
                x = 0;
            if (x > Wheight-100)
                x = Wheight - 100;
            if (y < 0)
                y = 0;
            if (y > Wwidth-100)
                y = Wwidth - 100;
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                x -= speed;
                up = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                x += speed;
                down = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                y -= speed;
                left = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                y += speed;
                right = true;
            }
            }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                down = false;
            if (e.KeyCode == Keys.Up)
                up = false;
            if (e.KeyCode == Keys.Left)
                left = false;
            if (e.KeyCode == Keys.Right)
                right = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            pl1.draw(e.Graphics);
            pl2.draw(e.Graphics);
        }
    }
}
