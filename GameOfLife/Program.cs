using GameOfLife.Business;
using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(10,10);
            board.Populate("..........,..x.......,x.x.......,.xx.......,..........,..........,..........,..........,..........,..........");

            int c = 0;

            while (true)
            {
                c++;
                if (c > 35) break;

                Console.Clear();

                foreach (string r in board.Output())
                {
                    Console.WriteLine(r);
                }

                board.GetNextState();
                System.Threading.Thread.Sleep(200);
            }
        }

    }
}
