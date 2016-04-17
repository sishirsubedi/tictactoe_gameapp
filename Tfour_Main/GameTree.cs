using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfour_Main
{
    class GameTree
    {
        const int OPONENT = 1, COMPUTER = 2, INFINITY = 1000000000;
        GameNode root;
        class GameNode
        {
            public int EvaluationScore { get; private set; }
            /************************************************************************
            * Move is an array (x, y) representing the Board entry that was changed *
            *      to get from the parent gameState to the present GameNode         *
            ************************************************************************/
            public int[] Move { get; private set; }
            /***********************************************
            * board is the state of the board at this node *
            ***********************************************/
            public Board GameBoard { get; private set; }
            /**********************************************************
            * The children of a node are all the possible GameStates  *
            *      the currentPlayer's valid moves can lead too       *
            **********************************************************/
            public List<GameNode> Children { get; set; }
            public bool GameOver
            {
                get
                {
                    if (GameBoard.isFull()) return true;
                    else return false;
                }
            }
            int Evaluation()
            {
                int oponentScore = GameBoard.getPlayerOneScore();
                int computerScore = GameBoard.getPlayerTwoScore();
                if (GameOver)
                {
                    // Computer won
                    if (computerScore > oponentScore) return INFINITY;
                    // Opponent won
                    if (oponentScore > computerScore) return -INFINITY;
                }
                return computerScore - oponentScore;
            }
            /***********************
            * GameNode Constructor *
            ***********************/
            public GameNode(Board GameBoard, int[] Move = null)
            {
                if (GameBoard == null)
                    throw new ArgumentNullException("Failed to find an instance of Board class to initialize the gameState.");

                this.GameBoard = GameBoard;
                this.Move = Move;
                EvaluationScore = Evaluation();
            }
        }
        /***********************
        * GameTree Constructor *
        ***********************/
        public GameTree(Board initialBoardState)
        {
            if (initialBoardState == null)
                throw new ArgumentNullException("Failed to find an instance of Board class to specify the initial state (or root) of the gameTree.");
            /*********************************
            * The computer always goes first *
            *********************************/
            root = new GameNode(initialBoardState);
            root.Children = GetChildren(root);
        }
        public int[] Decision()
        {
            /*******************************************************************************
            * The children of the root node is the set of moves the computer can pick from *
            *******************************************************************************/
            int maximumEvaluation = root.Children.Max(gameNode => gameNode.EvaluationScore);
            GameNode goodGameNode = root.Children.Find(gameNode => gameNode.EvaluationScore == maximumEvaluation);
            return goodGameNode.Move;
        }
        /************************************************************************************
        * GetChildren returns the list all the possible moves that can follow this GameNode *
        ************************************************************************************/
        List<GameNode> GetChildren(GameNode root)
        {
            int[] move = null;
            Board newBoard = null;
            GameNode newGameNode = null;
            List<GameNode> children = null;
            if (!root.GameOver)
            {
                children = new List<GameNode>();
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        /******************************************************
                        *     If the board entry (i, j) is free, then the     *
                        *   current player can place their token in that cell *
                        ******************************************************/
                        if (root.GameBoard.isFree(i, j))
                        {
                            move = new int[2] { i, j };
                            newBoard = new Board(root.GameBoard);
                            newBoard.updateBoard(i, j, COMPUTER);

                            newGameNode = new GameNode(newBoard, move);

                            children.Add(newGameNode);
                        }
                    }
                }
            }
            return children;
        }
    }
}
