using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cserélegtős_Játék_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] csereTomb = new bool[7, 7];
            int x, y;
            Matrix teszt = new Matrix();            
            Matrix.init(csereTomb);
            
            while (!Matrix.isOver(csereTomb))
            {
                Console.Clear();
                Console.WriteLine(Matrix.state(csereTomb));
                Console.WriteLine("Add meg az X koordinátát: ");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine("Add meg az Y koordinátát: ");
                y = int.Parse(Console.ReadLine());
                Matrix.shoot(csereTomb, x, y);                
            }

            Console.ReadLine();
        }

    }

    class Matrix
    {
        public static void init(bool[,] game)
        {            
            int middleX = game.GetLength(0) / 2;
            int middleY = game.GetLength(1) / 2;
            game[middleX, middleY] = true;
            game[middleX-1, middleY] = true;
            game[middleX+1, middleY] = true;
            game[middleX, middleY-1] = true;
            game[middleX, middleY+1] = true;
        }

        public static void kiir(bool[,] matrix)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    Console.Write("{0} ", matrix[x, y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(" ");
        }

        public static string state(bool[,] game)
        {
            string tabla = "";

            for (int x = 0; x < game.GetLength(0); x++)
            {
                for (int y = 0; y < game.GetLength(1); y++)
                {
                    if (game[x,y])
                    {
                        tabla += "* ";
                    }
                    else
                    {
                        tabla += "- ";
                    }
                    
                }
                tabla += "\n";
            }
                        
            return tabla;
        }

        public static void shoot(bool[,] game, int x, int y)
        {
            
            game[x, y] = !game[x, y];

            if (x > 0)
            {
                
                game[x - 1, y ] = !game[x - 1, y];

            }

            if (x < game.GetLength(0) - 1)
            {

                game[x + 1, y] = !game[x + 1, y];

            }

            if (y > 0)
            {

                game[x, y - 1] = !game[x, y - 1];

            }

            if (y < game.GetLength(1) - 1)
            {

                game[x, y + 1] = !game[x, y + 1];

            }
        }

        public static bool isOver(bool[,] game)
        {
            for (int i = 0; i < game.GetLength(0); i++)
            {
                for (int j = 0; j < game.GetLength(1); j++)
                {
                    if (!game[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;            
        }
    }
}



