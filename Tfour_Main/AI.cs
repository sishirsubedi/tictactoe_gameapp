using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfour_Main
{
    class AI
    {
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
        private int[] hardMove()
        {
            GameTree gameTree = new GameTree(gameBoard);
            return gameTree.Decision();
        }
        #endregion
    }
}
