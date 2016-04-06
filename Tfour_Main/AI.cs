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



            return cell;

        }

        private int[] mediumMove()
        {
            int[] cell = { 0, 0 };



            return cell;
        }

        private int[] hardMove()
        {
            int[] cell = { 0, 0 };



            return cell;
        }
    }
}
