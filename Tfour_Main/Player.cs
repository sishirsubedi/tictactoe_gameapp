using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfour_Main
{
    class Player
    {
        private String playerID;
   
        private Boolean playerTurn;
        private Boolean Winner;
        private int gameScore;

        public Player() { }

        public Player(string name, Boolean turn)
        {
            playerID = name;
            playerTurn = turn;
            Winner = false;
            gameScore = 0;

        }


        public void setPlayerTurn(Boolean turn)
        {
            playerTurn = turn;
        }

        public Boolean getPlayerTurn()
        {

            return playerTurn;
        }

        public void setWinner( Boolean winner)
        {
            Winner = winner;
        }

        public void setScore ( int score)
        {
            gameScore = score;
        }

        public string getPlayerID()
        {

            return playerID;
        }

        public int getScore()
        {
            return gameScore;
        }

        public Boolean isWinner()
        {
            return Winner;
        }
    }
}
