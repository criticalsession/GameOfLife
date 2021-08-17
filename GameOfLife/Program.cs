using GameOfLife.Business;
using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Board board = new Board(7,14);
            board.Populate("x..xxx.x..xxx.,..x.x....x.x..,..............,xxx.x..xxx.x..,.x.x.x..x.x.x.,xxx.xxxxxx.xxx,......x......x");

            foreach (string r in board.Output())
            {
                Console.WriteLine(r);
            }

            Console.ReadLine();
        }
    }
}
