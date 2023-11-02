using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static int[,] maze = new int[10, 10];
    static Random random = new Random();

    static void Main(string[] args)
    {
        int start = 0;
        int start1 = 0;

        GenerateMaze();
        PrintMaze();

        if (FindExit(start, start1))
            Console.WriteLine("exit found");
        else
            Console.WriteLine("there is no exit");

        PrintMaze();
    }

    static void GenerateMaze()
    {
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                if(random.Next(3) == 0)
                {
                    maze[i, j] = 1;
                }
                else
                {
                    maze[i, j] = 0;
                }
            }
        }
        maze[0,0] = 0;
        maze[9, 9] = 0;
    }

    static bool FindExit(int x, int y)
    {
        PrintMaze();
        if (x < 0 || y < 0 || x >= 10 || y >= 10 || maze[x,y] == 1)
            return false;

        if (maze[x, y] == 2)
            return false;

        if (x == 9 && y == 9)
            return true;

        maze[x, y] = 2;

        if (FindExit(x + 1, y) || FindExit(x, y + 1) || FindExit(x - 1, y) || FindExit(x, y - 1))
        {
            return true;
        }
        maze[x, y] = 0;
        return false;
    }

    static void PrintMaze()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (i == 9 && j == 9)
                {
                    Console.Write("E ");
                    break;
                }
                if (maze[i, j] == 1)
                    Console.Write("# ");
                else if (maze[i, j] == 0)
                    Console.Write(". ");
                else
                    Console.Write("O ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
