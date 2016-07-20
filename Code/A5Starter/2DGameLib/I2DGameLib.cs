using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DGameLib
{
    public interface I2DGameLib
    {
        void TakeTurn(_2DGameLib.Player activePlayer);
        int[] PiecePlacement(_2DGameLib.Player activePlayer);
        int[] ConvertToArrayLocation(string boardPosition);
        void PrintBoardMap();
        void PrintBoard();
        bool GameOver();
        void Start();
        bool CheckForFullBoard();

        Player GetActivePlayer();
        void SetActivePlayer(_2DGameLib.Player activePlayer);
    }
}
