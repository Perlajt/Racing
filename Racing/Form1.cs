using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gameover.Visible = false; // vykstant zaidimui game over nesimato
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveline(gamespeed); //zaidimo/liniju greitis
            enemy(gamespeed); //enemy greitis
            end(); //endgame
        }

        Random r = new Random();
        int x, y;
        void enemy(int speed)
        {
            if (enemy1.Top >= 500) //1st enemy spawn location
            { 
                x = r.Next(0, 200);
                enemy1.Location = new Point(x, 0);
            }
            else
            { enemy1.Top += speed; }

            if (enemy2.Top >= 500) //2nd enemy spawn location
            {
                x = r.Next(225, 250);
                enemy2.Location = new Point(x, 0);
            }
            else
            { enemy2.Top += speed; }

            if (enemy3.Top >= 500) //3rd enemy spawn location
            {
                x = r.Next(150, 400);
                enemy3.Location = new Point(x, 0);
            }
            else
            { enemy3.Top += speed; }
        }

        void end()
        {
            if(car.Bounds.IntersectsWith(enemy1.Bounds)) // game over lentele
            {
                timer1.Enabled = false;
                gameover.Visible = true;
            }
        }

        void moveline(int speed) //liniju judejimas
        {
            if(pictureBox1.Top >= 500)
            { pictureBox1.Top = 0; }
            else
            { pictureBox1.Top += speed; }

            if (pictureBox3.Top >= 500)
            { pictureBox3.Top = 0; }
            else
            { pictureBox3.Top += speed; }

            if (pictureBox4.Top >= 500)
            { pictureBox4.Top = 0; }
            else
            { pictureBox4.Top += speed; }

            if (pictureBox5.Top >= 500)
            { pictureBox5.Top = 0; }
            else
            { pictureBox5.Top += speed; }

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        int gamespeed = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) //judejimas i kaire
            {
                if (car.Left > 0)
                {
                    car.Left += -gamespeed;
                }
            }

            if(e.KeyCode == Keys.Right) //judejimas i desine
            {
                if(car.Right < 380)
                {
                    car.Left += 8;
                }
            }

            if(e.KeyCode == Keys.Up) //zaidimo pagreitinimas
            {
                if(gamespeed < 21)
                {
                    gamespeed++;
                }
            }

            if(e.KeyCode == Keys.Down) //zaidimo suletinimas
            {
                if(gamespeed > 0)
                {
                    gamespeed--;
                }
            }
        }
    }
}
