using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfour_Main
{// This module describes the game board which has 2d integer array and scores for two players.
    // it also has calculate score function to calculate score using horizontal, diagonal, and vertical direction
    // to find consecutive 4 or more same stones.
    class Board
    {
        private int[,] gameBoard;
        private int playerOneScore;
        private int playerTwoScore;

        private int[] lastMove = { -1, -1 };

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

        /*
 This module updates the data structure (2d integer array) and marks the cells for the player who clicked on it.  
1.	Takes in three integers as arguments. First two are row and column number and third one is either 1 and 2 for player one and player two respectively.
2.	Call calculateScore() to update scores for player one and player two score.

         
         */
        public void updateBoard(int x, int y, int playerNumber)
        {
            // update 1 or 2 for each player
            if (playerNumber == 1) { 
                gameBoard[x, y] = 1;
                lastMove[0] = x;
                lastMove[1] = y; }
            else
                gameBoard[x, y] = 2;

            // check any new score is made and update the player score
            calculateScore();


        }

        public void deleteLastMove (int x, int y)
        {
           
                gameBoard[x, y] = 0;
        }


        /*
         This module checks the current status of the board and calculates the score for both players.
1.	Loop through all the cells in the game board.
2.	Call checkHorizontal, checkVertical, and checkDiagonal to check if there are consecutive four or more stones in horizontal, vertical and diagonal direction.
3.	Update the score for players.

    */

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


        /*
         This module checks if there are four or more consecutive stones in a horizontal direction and updates the score for each player.
1.	Check horizontal input. Since to make four or more stones in a horizontal direction you need to have third column in it, check only third column.
2.	If four consecutive stones then add score one for that player score.
3.	If more than four then add one score for fifth and another one score for sixth consecutive score.

         */
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


        /*
         This module checks if there are four or more consecutive stones in a vertical direction and updates the score for each player.
1.	Check vertical input. Since to make four or more stones in a vertical direction you need to have third row in it, check only third row.
2.	If four consecutive stones then add score one for that player score.
3.	If more than four then add one score for fifth and another one score for sixth consecutive score.

         */

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

        /*
 This module checks if there are four or more consecutive stones in a diagonal direction and updates the score for each player.
1.	Check diagonal input. Check first three rows in both left and right direction.
2.	If four consecutive stones then add score one for that player score.
3.	If more than four then add one score for fifth and another one score for sixth consecutive score.
*/

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

        public void setPlayerOneScore( int score)
        {
            playerOneScore = score;
        }

        public void setPlayerTwoScore(int score)
        {
            playerTwoScore = score;
        }


        // This modules returns current game board matrix.
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


        // This modules fills game board matrix
        public void setGameMatrix( int [,] matrix)
        {

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    gameBoard[i, j] = matrix[i, j];
                }
            }
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


        public int[] getLastMove()
        {

            return lastMove;
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
 
 