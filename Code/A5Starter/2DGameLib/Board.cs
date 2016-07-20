using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameLib
{
    public class Board
    {
        public char[,] board;
        public Board(int boardSize)
        {
            board = new char[boardSize, boardSize];
        }
    }
}
