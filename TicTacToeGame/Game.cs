using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOPS_Practise.TicTacToeGame
{
    public class Game
    {
        IList<Player> playerList = new List<Player>();
        Board? b;
        int maxNumberOfMoves;

        public void initilizeBoard(int size)
        {
            b = new Board(size);
            maxNumberOfMoves = size * size;
        }
        public void addPlayer(Player p)
        {
            playerList.Add(p);
        }

        private List<int> parseInput(string? input)
        {
            string[] commadSeperatedValues = input.Split(',');
            if (commadSeperatedValues.Length >= 3)
            {
                Console.WriteLine("Not a valid input Please enter valid input");
                return new() { };
            }

            string firstVal = commadSeperatedValues[0].Trim();
            string secondVal = commadSeperatedValues[1].Trim();

            if (firstVal.Length == 0 || secondVal.Length == 0)
            {
                Console.WriteLine("Not a valid input Please enter valid input");
                return new() { };
            }

            return new() { int.Parse(firstVal), int.Parse(secondVal) };
        }

        private string winnerString(string name = "")
        {
            string s = "So, winner is " + name;
            if (name == "")
            {
                s = "oops! Game has tied";
            }
            return s;
        }

        private bool playerMove(int row, int col, Type sign)
        {
            bool isRowMatched = true;
            bool isColumnMatched = true;
            bool isDaigonalMatched = true;
            bool isRDiagonalMatched = true;
            for (int i = 0; i < b?.size; i++)
            {
                if (b?.board[i, col] != sign)
                {
                    isRowMatched = false;
                }
                if (b?.board[row, i] != sign)
                {
                    isColumnMatched = false;
                }
            }
            int r = 0, c = 0;

            while (r < b?.size)
            {
                if (b?.board[r, c] != sign)
                {
                    isDaigonalMatched = false;
                }
                r++;
                c++;
            }
            r = 0;
            c = b.size - 1;

            while (r < b?.size)
            {
                if (b?.board[r, c] != sign)
                {
                    isRDiagonalMatched = false;
                }
                r++;
                c--;
            }
            return isRDiagonalMatched || isDaigonalMatched || isRowMatched || isColumnMatched;
        }

        public string startGame()
        {
            Console.WriteLine("Let's start game");
            int numberOfMoves = 1;
            Console.WriteLine(playerList[0]);
            int index = 0;
            while (numberOfMoves <= maxNumberOfMoves)
            {
                Player currentPlayer = playerList[index];
                Console.WriteLine($"Now the turn is {currentPlayer.userName} Which has sign {currentPlayer.playerSignType}");
                for (int i = 0; i < b.size; i++)
                {
                    for (int j = 0; j < b.size; j++)
                    {
                        if (b.board[i, j] == Type.cross)
                        {
                            Console.Write("x | ");
                        }
                        if (b.board[i, j] == Type.round)
                        {
                            Console.Write("O | ");
                        }
                        if (b.board[i, j] == Type.Empty)
                        {
                            Console.Write("  | ");
                        }
                    }
                    Console.WriteLine();
                }
                bool isValidInput = false;
                int firstValue;
                int secondValue;


                while (!isValidInput)
                {
                    Console.WriteLine("Enter your comma seperated value(row,column) here: ");
                    string? input = Console.ReadLine();
                    List<int> inputVal = parseInput(input);
                    if (inputVal.Count == 0)
                    {
                        Console.WriteLine("Please enter correct value");
                        continue;
                    }
                    if (b?.board[inputVal[0], inputVal[1]] != Type.Empty || inputVal[0] >= b.size || inputVal[1] >= b.size)
                    {
                        Console.WriteLine("Please enter correct value");
                        continue;
                    }
                    firstValue = inputVal[0];
                    secondValue = inputVal[1];
                    b.board[firstValue, secondValue] = currentPlayer.playerSignType;
                    bool isThisPlayerWinner = playerMove(firstValue, secondValue, currentPlayer.playerSignType);
                    if (isThisPlayerWinner)
                    {
                        return winnerString(currentPlayer.userName);
                    }
                    isValidInput = true;
                }
                numberOfMoves++;
                index = (index + 1) % playerList.Count;
            }
            return winnerString();
        }

    }
}