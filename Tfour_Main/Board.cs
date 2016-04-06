using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfour_Main
{
    class Board
    {
        private int[,] gameBoard; 
        private int playerOneScore;
        private int playerTwoScore;

        public Board()
        {
            gameBoard = new int[6, 6];


            // initialize board to have all zeros
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    gameBoard[i, j] = 0;
                }


            }
            // initialize both players score as zero
            playerOneScore = 0;
            playerTwoScore = 0;

        }

        public void updateBoard(int x, int y, int playerNumber)
        {
            // update 1 or 2 for each player
            if (playerNumber == 1)
               gameBoard[x, y] = 1;
            else
                gameBoard[x, y] = 2;

            // check any new score is made and update the player score
            calculateScore();

        }

        private void calculateScore()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (gameBoard[i,j] == 1)
                    {

                        playerOneScore += checkHorizontal(i, j);
                        playerOneScore += checkVertical(i, j);
                        playerOneScore += checkDiagnol(i, j);
                    }
                    else if (gameBoard[i, j] == 2)
                    {

                        playerTwoScore += checkHorizontal(i, j);
                        playerTwoScore += checkVertical(i, j);
                        playerTwoScore += checkDiagnol(i, j);
                    }

                }

            }

        }

        private int checkHorizontal(int x, int y)
        {
            int status = 0;

            switch (y)
            { 
                case 3:
                    if ((gameBoard[x, y] == gameBoard[x, y - 3] && gameBoard[x, y] == gameBoard[x, y - 2] && gameBoard[x, y] == gameBoard[x, y - 1])
                        || (gameBoard[x, y] == gameBoard[x, y - 2] && gameBoard[x, y] == gameBoard[x, y - 1] && gameBoard[x, y] == gameBoard[x, y + 1])
                        || (gameBoard[x, y] == gameBoard[x, y - 1] && gameBoard[x, y] == gameBoard[x, y + 1] && gameBoard[x, y] == gameBoard[x, y + 2]))
                    {
                        status++;
                    }

                    if ((gameBoard[x, y] == gameBoard[x, y - 3] && gameBoard[x, y] == gameBoard[x, y - 2] && gameBoard[x, y] == gameBoard[x, y - 1])
                       && (gameBoard[x, y] == gameBoard[x, y - 2] && gameBoard[x, y] == gameBoard[x, y - 1] && gameBoard[x, y] == gameBoard[x, y + 1]))
                    {
                        status++;
                    }

                    else if ((gameBoard[x, y] == gameBoard[x, y - 3] && gameBoard[x, y] == gameBoard[x, y - 2] && gameBoard[x, y] == gameBoard[x, y - 1])
                       && (gameBoard[x, y] == gameBoard[x, y - 1] && gameBoard[x, y] == gameBoard[x, y + 1] && gameBoard[x, y] == gameBoard[x, y + 2]))
                    {
                        status++;
                    }
                    else if ((gameBoard[x, y] == gameBoard[x, y - 2] && gameBoard[x, y] == gameBoard[x, y - 1] && gameBoard[x, y] == gameBoard[x, y + 1])
                       && (gameBoard[x, y] == gameBoard[x, y - 1] && gameBoard[x, y] == gameBoard[x, y + 1] && gameBoard[x, y] == gameBoard[x, y + 2]))
                    {
                        status++;
                    }
                    if ((gameBoard[x, y] == gameBoard[x, y - 3] && gameBoard[x, y] == gameBoard[x, y - 2] && gameBoard[x, y] == gameBoard[x, y - 1])
                        && (gameBoard[x, y] == gameBoard[x, y - 2] && gameBoard[x, y] == gameBoard[x, y - 1] && gameBoard[x, y] == gameBoard[x, y + 1])
                       && (gameBoard[x, y] == gameBoard[x, y - 1] && gameBoard[x, y] == gameBoard[x, y + 1] && gameBoard[x, y] == gameBoard[x, y + 2]))
                    {
                        status++;
                    }
                    break;

                default:
                    break;

            }
            return status;

        }

        private int checkVertical(int x, int y)
        {
            int status = 0;

            switch (x)
            {
                case 3:
                    if ((gameBoard[x, y] == gameBoard[x - 3, y] && gameBoard[x, y] == gameBoard[x - 2, y] && gameBoard[x, y] == gameBoard[x - 1, y])
                        || (gameBoard[x, y] == gameBoard[x - 2, y] && gameBoard[x, y] == gameBoard[x - 1, y] && gameBoard[x, y] == gameBoard[x + 1, y])
                        || (gameBoard[x, y] == gameBoard[x - 1, y] && gameBoard[x, y] == gameBoard[x + 1, y] && gameBoard[x, y] == gameBoard[x + 2, y]))
                    {
                        status++;
                    }

                    if ((gameBoard[x, y] == gameBoard[x - 3, y] && gameBoard[x, y] == gameBoard[x - 2, y] && gameBoard[x, y] == gameBoard[x - 1, y])
                         && (gameBoard[x, y] == gameBoard[x - 2, y] && gameBoard[x, y] == gameBoard[x - 1, y] && gameBoard[x, y] == gameBoard[x + 1, y]))

                    {
                        status++;
                    }
                    else if ((gameBoard[x, y] == gameBoard[x - 3, y] && gameBoard[x, y] == gameBoard[x - 2, y] && gameBoard[x, y] == gameBoard[x - 1, y])
                       && (gameBoard[x, y] == gameBoard[x - 1, y] && gameBoard[x, y] == gameBoard[x + 1, y] && gameBoard[x, y] == gameBoard[x + 2, y]))
                    {
                        status++;
                    }
                    else if ((gameBoard[x, y] == gameBoard[x - 2, y] && gameBoard[x, y] == gameBoard[x - 1, y] && gameBoard[x, y] == gameBoard[x + 1, y])
                        && (gameBoard[x, y] == gameBoard[x - 1, y] && gameBoard[x, y] == gameBoard[x + 1, y] && gameBoard[x, y] == gameBoard[x + 2, y]))
                    {
                        status++;
                    }
                    if ((gameBoard[x, y] == gameBoard[x - 3, y] && gameBoard[x, y] == gameBoard[x - 2, y] && gameBoard[x, y] == gameBoard[x - 1, y])
                    && (gameBoard[x, y] == gameBoard[x - 2, y] && gameBoard[x, y] == gameBoard[x - 1, y] && gameBoard[x, y] == gameBoard[x + 1, y])
                    && (gameBoard[x, y] == gameBoard[x - 1, y] && gameBoard[x, y] == gameBoard[x + 1, y] && gameBoard[x, y] == gameBoard[x + 2, y]))
                    {
                        status++;
                    }

                    break;

               default:
                    break;


            }
            return status;

        }

        private int checkDiagnol(int x, int y)
        {
            int status = 0;

            if (x == 0 && y < 3)
            {

                if (gameBoard[x, y] == gameBoard[x + 1, y + 1] && gameBoard[x, y] == gameBoard[x + 2, y + 2] && gameBoard[x, y] == gameBoard[x + 3, y + 3])

                {
                    status++;
                }

            }

            else if (x == 1 && y < 3)
            {

                if (gameBoard[x, y] == gameBoard[x + 1, y + 1] && gameBoard[x, y] == gameBoard[x + 2, y + 2] && gameBoard[x, y] == gameBoard[x + 3, y + 3])
                {
                    status++;
                }

            }
            else if (x == 2 && y < 3)
            {

                if (gameBoard[x, y] == gameBoard[x + 1, y + 1] && gameBoard[x, y] == gameBoard[x + 2, y + 2] && gameBoard[x, y] == gameBoard[x + 3, y + 3])
                {
                    status++;
                }

            }

            if (x == 0 && y > 2)
            {

                if (gameBoard[x, y] == gameBoard[x + 1, y - 1] && gameBoard[x, y] == gameBoard[x + 2, y - 2] && gameBoard[x, y] == gameBoard[x + 3, y - 3])
                {
                    status++;
                }

            }

            else if (x == 1 && y > 2)
            {

                if (gameBoard[x, y] == gameBoard[x + 1, y - 1] && gameBoard[x, y] == gameBoard[x + 2, y - 2] && gameBoard[x, y] == gameBoard[x + 3, y - 3])
                {
                    status++;
                }

            }
            else if (x == 2 && y > 2)
            {

                if (gameBoard[x, y] == gameBoard[x + 1, y - 1] && gameBoard[x, y] == gameBoard[x + 2, y - 2] && gameBoard[x, y] == gameBoard[x + 3, y - 3])
                {
                    status++;
                }

            }


            return status;

        }


        public int getPlayerOneScore() { return playerOneScore; }


        public int getPlayerTwoScore() { return playerTwoScore; }

    }
}
