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

        public Board(Board board)
        {
            gameBoard = board.getGameMatrix();
            calculateScore();
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
            playerOneScore = 0;
            playerTwoScore = 0;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (gameBoard[i, j] == 1)
                    {
                        playerOneScore += checkHorizontal(i, j);
                        playerOneScore += checkVertical(i, j);
                        playerOneScore += checkDiagonal(i, j);
                    }
                    else if (gameBoard[i, j] == 2)
                    {
                        playerTwoScore += checkHorizontal(i, j);
                        playerTwoScore += checkVertical(i, j);
                        playerTwoScore += checkDiagonal(i, j);
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

        private int checkDiagonal(int x, int y)
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

        public int[,] getGameMatrix()
        {
            int[,] gameMatrix = new int[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    gameMatrix[i, j] = gameBoard[i, j];
                }
            }
            return gameMatrix;
        }

        public bool isFull()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (gameBoard[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool isFree(int x, int y)
        {
            if (gameBoard[x, y] == 0)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder boardString = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    boardString.Append(gameBoard[i, j] + " ");
                }
                boardString.Append("\n");
            }
            return boardString.ToString();
        }
    }
}