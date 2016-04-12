using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfour_Main
{
    class ComputerPlayer : Player
    {
        private string playerLevel;
        private AI superMario;

        public ComputerPlayer() { }

        public ComputerPlayer(string name, Boolean turn, Board gboard, string glevel)
            : base (name, turn)
        {
          
            superMario = new AI(gboard, glevel);

        }


        public AI getAI()
        {
            return superMario;
        }
        



    }
}
