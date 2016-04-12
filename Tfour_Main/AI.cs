using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfour_Main
{ //test
    class AI
    {

        private Board gameBoard;
        private string gameLevel;
        private Boolean isEasy;
        private Boolean isMedium;
        private Boolean isHard;


        AI() { }

        public AI (Board gboard, string glevel)
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
            int[] cell = { 0, 0 };

            if (isEasy) cell = easyMove();

            if (isMedium) cell = mediumMove();

            if (isHard) cell = hardMove();

            return cell;
        }


        private int[] easyMove()
        {
            int[] cell = { 0, 0 };
            Boolean checking = true;
            Random rand = new Random();
           
            int randRow = rand.Next(0, 6), randCol = rand.Next(0, 6);

            while (checking)
            {
                
                        if (gameBoard.getGameMatrix()[randRow,randCol] == 0)
                        {
                            checking = false;

                        } else
                        {
                             randCol = rand.Next(0, 6);
                              randRow = rand.Next(0, 6);
                        }
         

            }

            cell[0] = randRow;
            cell[1] = randCol;

            return cell;

        }

        private int[] mediumMove()
        {
            int[] cell = { 7, 7 };



            return cell;
        }

        private int[] hardMove()
        {
            int[] cell = { 10, 10 };



            return cell;
        }
    }
}
