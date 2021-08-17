using GameOfLife.Business;
using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(7,14);
            board.Populate("x..xxx.x..xxx.,..x.x....x.x..,..............,xxx.x..xxx.x..,.x.x.x..x.x.x.,xxx.xxxxxx.xxx,......x......x");

            int c = 0;

            while (true)
            {
                c++;
                if (c > 10) break;

                Console.Clear();

                foreach (string r in board.Output())
                {
                    Console.WriteLine(r);
                }

                board.GetNextState();
                System.Threading.Thread.Sleep(1000);
            }
        }

    }
}
