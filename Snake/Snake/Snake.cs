using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        public Rectangle[] snakeRec;
        public Rectangle[] snakeRecBig
        {
            get
            {
                return snakeRec;
            }
        }
        private SolidBrush brush;
        private int x, y, width, height;

        //Khoi tao ran

        public Snake()
        {
            snakeRec = new Rectangle[3];
            brush = new SolidBrush(Color.Blue);
            x = 20; y = 40; width = 10; height = 10;
            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }
        }
        public void drawSnake(Graphics paper)
        {
            foreach (Rectangle rec in snakeRec)
            {
                paper.FillEllipse(brush, rec);
            }
        }
        // ve ran trong luc chay
        public void drawSnakeRun()
        {
            for (int i = snakeRec.Length - 1; i > 0; i--)
            {
                snakeRec[i] = snakeRec[i - 1];
            }
        }
        public void moveDown()
        {
            drawSnakeRun();
            snakeRec[0].Y += 10;
        }
        public void moveUP()
        {
            drawSnakeRun();
            snakeRec[0].Y -= 10;
        }
        public void moveRight()
        {
            drawSnakeRun();
            snakeRec[0].X += 10;
        }
        public void moveLeft()
        {
            drawSnakeRun();
            snakeRec[0].X -= 10;
        }
        public void BigSnake()
        {
            List<Rectangle> rec = snakeRec.ToList();
            rec.Add(new Rectangle(snakeRec[snakeRec.Length - 1].X, snakeRec[snakeRec.Length - 1].Y, width, height));
            snakeRec = rec.ToArray();
        }
    }
}
