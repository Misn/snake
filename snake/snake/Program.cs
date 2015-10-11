using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(120, 30);
            //Console.WriteLine(Console.LargestWindowWidth);
            //Console.WriteLine(Console.LargestWindowHeight);
            //Console.WriteLine(Console.WindowLeft + Console.WindowWidth);
            //Console.WriteLine(Console.WindowTop + Console.WindowHeight);

            HorizontalLine upLine = new HorizontalLine(0, 118, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, 118, 29, '+');
            VerticalLine leftLine = new VerticalLine(0, 29, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, 29, 118, '+');
            upLine.Draw();
            downLine.Draw();
            leftLine.Draw();
            rightLine.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.DOWN);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(120, 30, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();
            
            while(true)
            {
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            //Console.ReadLine();
        }
    }
}
