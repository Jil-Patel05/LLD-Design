using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.TicTacToeGame
{
    public class Board
    {
        public int size;
        public Type[,] board;
        public Board(int size)
        {
            this.board = new Type[size, size];
            this.size = size;
        }
    }
}