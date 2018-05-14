using System;
using System.Drawing;
using System.Windows.Forms;

namespace Курсовая_по_ООП
{
    public partial class Form1 : Form
    {
        Game _game;





        bool right;
        bool left;
        bool jump;
        int G = 20;
        int Force;
        int index = 0;

        public Form1()
        {
            InitializeComponent();
           // block.Top = screen.Height - block.Height;  //начальная позиция блока
            player.Top = screen.Height - player.Height;  //начальная позиция игрока

            _game = new Game();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            index++;
            //Gif replay
            //if (right == true && index % 15 == 0)
            //{
            //    player.Image = Image.FromFile("run_right_gif.gif");
            //}
            //if (left == true && index % 15 == 0)
            //{
            //    player.Image = Image.FromFile("run_left_gif.gif");
            //}


            //Slide Collision
            // Игрок двигается слева от кирпича

            //if (player.Right > block.Left && player.Left < block.Right - player.Width / 2 && player.Bottom > block.Top)
            //{
            //    right = false;

            //}
            if (player.Right > block.Left && player.Left < block.Right - player.Width && player.Bottom < block.Bottom && player.Bottom > block.Top)
            {
                right = false;

            }
            // Игрок двигается справа от кирпича
            if (player.Left < block.Right && player.Right > block.Right + player.Width && player.Bottom < block.Bottom && player.Bottom > block.Top)
            {
                left = false;
            }


            if (right == true) { player.Left += 3; }
            if (left == true) { player.Left -= 3; }

            //если игрок прыгнул раньше
            if (jump == true)
            {
                player.Top -= Force;  //прыжок вверх
                Force -= 1;  //убывание высоты прыжка
            }
            if (player.Top + player.Height >= screen.Height)  //вышли за границы формы снизу
            {
                player.Top = screen.Height - player.Height; //остановить падение
                if (jump == true)
                {
                    player.Image = Image.FromFile("stand_png.png");
                }
                jump = false;
            }
            else
            {
                player.Top += 5; //падение
            }

            //Top Collision

 
            if (player.Left + player.Width - 5 > block.Left
            && player.Left + player.Width + 5 < block.Left + block.Width + player.Width
               && player.Top + player.Height >= block.Top && player.Top < block.Top)
            {
                jump = false;
                Force = 0;
                player.Top = block.Location.Y - player.Height;
            }
            //На блоке
            //if (player.Left + player.Width - 5 > block.Left
            //&& player.Left + player.Width + 5 < block.Left + block.Width + player.Width
            //   && player.Top - block.Bottom <= 10 && player.Top - block.Top > -10)
            //{
            //    Force = 0;
            //}
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Вызов метода класса Game для обработки нажатия клавиши, перехваченного формой
            _game.HandleKeyDown((int)e.KeyCode);

            if (e.KeyCode == Keys.Right)
            {
                right = true;
                // player.Image = Image.FromFile("run_right_gif.gif");
            }
            if (e.KeyCode == Keys.Left)
            {
                left = true;
                // player.Image = Image.FromFile("run_left_gif.gif");
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }  //Escape - закрываем форму
            if (jump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    jump = true;
                    Force = G;
                    player.Image = Image.FromFile("jump_png.png");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                right = false;
                player.Image = Image.FromFile("stand_png.png");
            }
            if (e.KeyCode == Keys.Left)
            {
                left = false;
                // TODO: загружать изображения персонажа при старте
                player.Image = Image.FromFile("stand_png.png");
               /// Math.Cos
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void block_Click(object sender, EventArgs e)
        {

        }
    }
}