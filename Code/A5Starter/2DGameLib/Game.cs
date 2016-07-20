using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameLib
{
    public class Game
    {
        public _2DGameLib.Player activePlayer;
        public Board board;
        public _2DGameLib.Player[] players;

        public void Gameloop(I2DGameLib game, int boardSize)
        {
            board = new Board(boardSize);
            int indexOfCurrentPlayer = 0;
            game.SetActivePlayer(players[indexOfCurrentPlayer]);

            while (!game.GameOver())
            {
                game.PrintBoard();
                
                game.TakeTurn(game.GetActivePlayer());
                //select the other player
                indexOfCurrentPlayer = (indexOfCurrentPlayer == 0) ? 1 : 0;
                game.SetActivePlayer(players[indexOfCurrentPlayer]);

                //Added this slight delay for user experience.  Without it it's harder to notice the board repaint
                //try commenting it out and check out the difference.  Which do you prefer?
                System.Threading.Thread.Sleep(300);
            }
        }
        public Player GetActivePlayer()
        {
            return activePlayer;
        }

        public void SetActivePlayer(Player _activePlayer)
        {
            activePlayer = _activePlayer;
        }

        public char GetBoard(int row, int column)
        {
            return board.board[row,column];
        }

        public void SetBoard(int row, int column, char playerSymbol)
        {
            board.board[row, column] = playerSymbol;
        }
    }
}
