using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        int score = 0;
        Random randFood = new Random();
        Food food;
        Graphics paper;
        Snake snake = new Snake();
        Boolean up = false, down = false, right = false, left = false;
        Player oPlay;
        Form2 form;
        GameHelper oHelper;
        public Form1(string name)
        {
            InitializeComponent();
            food = new Food(randFood);
            oPlay = new Player();
            oPlay.PlayerName = name;
            form = new  Form2();
            oHelper = new GameHelper();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            food.drawFood(paper);
            snake.drawSnake(paper);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {  

             
                timer1.Enabled = true;
                up = false;
                down = false;
                right = false;
                left = false;
                lbThongbao.Text = "";
            }
            if (e.KeyData== Keys.Up && down == false)
            {
                up = true;
                down = false;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Down && up == false)
            {
                up = false;
                down = true;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Right && left == false)
            {
                up = false;
                down = false;
                right = true;
                left = false;
            }
            if (e.KeyData == Keys.Left && right == false)
            {
                up = false;
                down = false;
                right = false;
                left = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusScore.Text = score.ToString();
            if (down == true) { snake.moveDown(); }
            if (up == true) {snake.moveUP();}
            if (right == true) {snake.moveRight();}
            if (left == true) { snake.moveLeft(); }
            //phat hien va cham
            for (int i = 0; i < snake.snakeRec.Length; i++)
            {
                if (snake.snakeRec[i].IntersectsWith(food.foodRec))
                {
                    score += 10;
                    snake.BigSnake();
                    food.foodLocation(randFood);
                }
            }
            VaCham();
            this.Invalidate();
        }
        public void VaCham()
        {
            for (int i = 1; i < snake.snakeRecBig.Length; i++)
            {
                if (snake.snakeRecBig[0].IntersectsWith(snake.snakeRecBig[i]))
                {
                    oPlay.Score = score;
                    oPlay.TimeScore = DateTime.Now.ToString();  
                    oHelper.SaveScore(oPlay);
                    Resart();
                   
                }
            }
            if (snake.snakeRecBig[0].Y<5||snake.snakeRecBig[0].Y > 280)
            {
                oPlay.Score = score;
                oPlay.TimeScore = DateTime.Now.ToString();  
                oHelper.SaveScore(oPlay);
                Resart();
            }
            if (snake.snakeRecBig[0].X <5 || snake.snakeRecBig[0].X > 280)
            {
                oPlay.Score = score;
                oPlay.TimeScore = DateTime.Now.ToString();  
                oHelper.SaveScore(oPlay);
                Resart();
                
            }
        }
        public void Resart()
        {
            timer1.Enabled = false;
            MessageBox.Show("Game Over");
            NewGame();
            //lbThongbao.Text = "Bấm phím Enter để bắt đầu chơi";
            //toolStripStatusScore.Text = "0";
            //score = 0;
            //snake = new Snake();
        }
        private void NewGame() {
            Form2 frm2 = new Form2();
            this.Close();
            frm2.Show();
            frm2.StartPosition = FormStartPosition.CenterScreen;
        }
        
    }
}
