using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfour_Main
{
   // This module describes AI module
    class AI
    {
        // AI fields
        private Board gameBoard;
        private string gameLevel;
        private Boolean isEasy;
        private Boolean isMedium;
        private Boolean isHard;

        public AI(Board gboard, string glevel)
        {
            gameBoard = gboard;
            gameLevel = glevel;

            if (glevel.Equals("Easy"))
            { isEasy = true; isMedium = false; isHard = false; }
            else if (glevel.Equals("Medium"))
            { isEasy = false; isMedium = true; isHard = false; }
            else if (glevel.Equals("Hard"))
            { isEasy = false; isMedium = false; isHard = true; }
        }

        public int[] findMove()
        {
            int[] cell = { -1, -1 };

            if (isEasy) cell = easyMove();

            if (isMedium) cell = mediumMove();

            if (isHard) cell = hardMove();

            return cell;
        }

        #region EASY

        /*This module checks the board and returns the cell number 
          for computer player to click using Randomization algorithms.

        1.	Check the current status of the game board.
        2.	Pick random number from 0-5 for row.
        3.	Pick random number from 0-5 for column.
        4.	Check if the cell with picked row and column number is available.
        5.	If the chosen cell is taken then produce another random cell until empty cell is chosen.
        6.	Return the row and column number of the cell as an integer array.

         * */
        private int[] easyMove()
{
    int[] cell = { -1, -1 };
    Boolean checking = true;
    Random rand = new Random();

    int randRow = rand.Next(0, 6), randCol = rand.Next(0, 6);

    while (checking)
    {
        if (gameBoard.getGameMatrix()[randRow, randCol] == 0)
        {
            checking = false;

        }
        else
        {
            randCol = rand.Next(0, 6);
            randRow = rand.Next(0, 6);
        }
    }

    cell[0] = randRow;
    cell[1] = randCol;

    return cell;
}
#endregion

#region MEDIUM
/*
 *This module checks the board and returns the cell number for computer player to click.  
1.	Check the current status of the game board.
2.	Calculate the change in score for offensive by checking computer player score.
3.	Calculate the change in score for defensive by checking human player score.
4.	Return the location if offensive or defensive is better.
5.	If both score are same then use look ahead strategy.
6.	Circular to check any score can be made with priority assigned.
7.	Second block to stop any consecutive third moves.
8.	Use down right, up right, down left, up left to block ahead moves.

*/
private int[] mediumMove()
{
    int[] cell = { -1, -1 };

    int next_x_offensive = -1;
    int next_y_offensive = -1;
    int next_x_defensive = -1;
    int next_y_defensive = -1;


    Board testBoard = new Board();

    testBoard.setGameMatrix(gameBoard.getGameMatrix());

    // offensive 

    testBoard.setPlayerTwoScore(gameBoard.getPlayerTwoScore());
    int trialScore = testBoard.getPlayerTwoScore();
    int oldScore = testBoard.getPlayerTwoScore();



    for (int i = 0; i < 6; i++)
    {
        for (int j = 0; j < 6; j++)
        {

            if (testBoard.isFree(i, j))
            {
                testBoard.updateBoard(i, j, 2);

                trialScore = testBoard.getPlayerTwoScore();

                if (trialScore > oldScore)
                {
                    next_x_offensive = i;
                    next_y_offensive = j;
                    j = 7;
                    i = 7;
                    Console.WriteLine("this is - OFFENSIVE ");
                    Console.WriteLine("--------------------");
                }
                else
                {
                    testBoard.deleteLastMove(i, j);
                }

            }
        }
    }

    //  defensive 

    testBoard.setPlayerOneScore(gameBoard.getPlayerOneScore());
    trialScore = testBoard.getPlayerOneScore();
    oldScore = testBoard.getPlayerOneScore();



    for (int i = 0; i < 6; i++)
    {
        for (int j = 0; j < 6; j++)
        {
            if (testBoard.isFree(i, j))
            {
                testBoard.updateBoard(i, j, 1);

                trialScore = testBoard.getPlayerOneScore();

                if (trialScore > oldScore)
                {
                    next_x_defensive = i;
                    next_y_defensive = j;
                    j = 7;
                    i = 7;
                    Console.WriteLine("this is - DEFENSIVE ");
                    Console.WriteLine("--------------------");
                }
                else
                {
                    testBoard.deleteLastMove(i, j);
                }
            }

        }
    }



    if (next_x_offensive == -1 && next_x_defensive != -1)
    {
        cell[0] = next_x_defensive;
        cell[1] = next_y_defensive;
    }
    else if (next_x_offensive != -1 && next_x_defensive == -1)
    {
        cell[0] = next_x_offensive;
        cell[1] = next_y_offensive;
    }
    else if (next_x_offensive != -1 && next_x_defensive != -1)
    {
        cell[0] = next_x_offensive;
        cell[1] = next_y_offensive;
    }

    else if (next_x_offensive == -1 && next_x_defensive == -1)
    {
        int[] lastMove = gameBoard.getLastMove();

        int lastMove_x = lastMove[0];
        int lastMove_y = lastMove[1];

        bool cellChanged = false;


        if (lastMove_x == -1 && lastMove_y == -1)
        {
            cell = easyMove();

        }
        else
        {






            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {

                    if (lastMove_x == i && lastMove_y == j)
                    {
                        Console.WriteLine("this is -  TACKLE  @ " + i + j);
                        Console.WriteLine("--------------------");
                        // circle
                        if (j <= 4 && j >= 1 && i <= 4 && i >= 1)
                        {
                            // two consecutive move block

                            if(gameBoard.getGameMatrix()[i,j]==1 && gameBoard.getGameMatrix()[i-1, j] == 1)
                            {

                                if (gameBoard.isFree(i + 1, j))
                                {
                                    cell[0] = i + 1;
                                    cell[1] = j;
                                    cellChanged = true;
                                }

                            }
                            else if (gameBoard.getGameMatrix()[i, j] == 1 && gameBoard.getGameMatrix()[i + 1, j] == 1)
                            {
                                if (gameBoard.isFree(i - 1, j))
                                {
                                    cell[0] = i - 1;
                                    cell[1] = j;
                                    cellChanged = true;
                                }
                            }
                            else if (gameBoard.getGameMatrix()[i, j] == 1 && gameBoard.getGameMatrix()[i , j-1] == 1)
                            {

                                if (gameBoard.isFree(i, j+1))
                                {
                                    cell[0] = i ;
                                    cell[1] = j+1;
                                    cellChanged = true;
                                }


                            }
                            else if (gameBoard.getGameMatrix()[i, j] == 1 && gameBoard.getGameMatrix()[i , j+1] == 1)
                            {

                                if (gameBoard.isFree(i, j - 1))
                                {
                                    cell[0] = i;
                                    cell[1] = j - 1;
                                    cellChanged = true;
                                }

                            }
                            else
                            {
                                cell = easyMove();
                            }

                            if (!cellChanged)
                            {

                                if (gameBoard.isFree(i - 1, j))

                                {
                                    cell[0] = i - 1;
                                    cell[1] = j;
                                }

                                else if (gameBoard.isFree(i + 1, j))

                                {
                                    cell[0] = i + 1;
                                    cell[1] = j;
                                }

                                else if (gameBoard.isFree(i, j - 1))
                                {
                                    cell[0] = i;
                                    cell[1] = j - 1;
                                }

                                else if (gameBoard.isFree(i, j + 1))

                                {
                                    cell[0] = i;
                                    cell[1] = j + 1;
                                }


                                else if (gameBoard.isFree(i - 1, j - 1))
                                {
                                    cell[0] = i - 1;
                                    cell[1] = j - 1;
                                }

                                else if (gameBoard.isFree(i + 1, j - 1))

                                {
                                    cell[0] = i + 1;
                                    cell[1] = j - 1;
                                }

                                else if (gameBoard.isFree(i + 1, j + 1))

                                {
                                    cell[0] = i + 1;
                                    cell[1] = j + 1;
                                }

                                else if (gameBoard.isFree(i - 1, j + 1))

                                {
                                    cell[0] = i - 1;
                                    cell[1] = j + 1;
                                }
                                else
                                {
                                    cell = easyMove();
                                }

                            }
                        } 
                        // down right
                        else if (i >= 0 && i <= 4 && j >= 0 && j <= 4)
                        {
                            if (gameBoard.isFree(i, j + 1))
                            {
                                cell[0] = i;
                                cell[1] = j + 1;
                            }
                            else if (gameBoard.isFree(i + 1, j + 1))
                            {
                                cell[0] = i + 1;
                                cell[1] = j + 1;
                            }
                            else if (gameBoard.isFree(i + 1, j))
                            {
                                cell[0] = i + 1;
                                cell[1] = j;
                            }
                            else
                            {
                                cell = easyMove();
                            }

                        }

                        //up right
                        else if (i <= 5 && i >= 1 && j >= 0 && j <= 4)
                        {
                            if (gameBoard.isFree(i, j + 1))
                            {
                                cell[0] = i;
                                cell[1] = j + 1;
                            }
                            else if (gameBoard.isFree(i - 1, j + 1))
                            {
                                cell[0] = i - 1;
                                cell[1] = j + 1;
                            }
                            else if (gameBoard.isFree(i - 1, j))
                            {
                                cell[0] = i - 1;
                                cell[1] = j;
                            }
                            else
                            {
                                cell = easyMove();
                            }

                        }
                        //down left
                        else if (j <= 5 && j >= 1 && i >= 0 && i <= 4)
                        {
                            if (gameBoard.isFree(i, j - 1))
                            {
                                cell[0] = i;
                                cell[1] = j - 1;
                            }
                            else if (gameBoard.isFree(i + 1, j - 1))
                            {
                                cell[0] = i + 1;
                                cell[1] = j - 1;
                            }
                            else if (gameBoard.isFree(i + 1, j))
                            {
                                cell[0] = i + 1;
                                cell[1] = j;
                            }
                            else
                            {
                                cell = easyMove();
                            }

                        }

                        // up left
                        else if (j <= 5 && j >= 1 && i <= 5 && i >= 1)
                        {
                            if (gameBoard.isFree(i, j - 1))
                            {
                                cell[0] = i;
                                cell[1] = j - 1;
                            }
                            else if (gameBoard.isFree(i - 1, j - 1))
                            {
                                cell[0] = i - 1;
                                cell[1] = j - 1;
                            }
                            else if (gameBoard.isFree(i - 1, j))
                            {
                                cell[0] = i - 1;
                                cell[1] = j;
                            }
                            else
                            {
                                cell = easyMove();
                            }


                        }



                    }


                }

            }


        }
    }




    return cell;
}
#endregion



#region HARD

/*
 A Board Node represents a cell on the game board. It contains adjacency relationships between 
 the given cell and its neighbors, the token contained by the cell, it’s position on the board 
 (row, column), and a score. This score is assigned through a heuristic process which aims to 
 quantify the quality of an empty node, i.e. a potential move.
 The Board Network is a 2 dimensional array of Board Nodes.  It is a reflection of the 
 current state of the Board object it is created from.
The Possible Moves available in a Board Network is the List of all its empty nodes.
*/



private int[] hardMove()
{
AIBoard aiBoard = new AIBoard(gameBoard);
return aiBoard.Decision();
}
#endregion
}
}
