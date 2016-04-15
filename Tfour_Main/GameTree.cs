using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfour_Main
{
    class GameTree
    {
        /****************************
        * OPONENT is the minimizer  *
        * COMPUTER is the maximizer *
        ****************************/
        const int OPONENT = 1, COMPUTER = 2;
        GameState root;
        /***************************************************************
        * the depth is a limit on the number of levels of the GameTree *
        ***************************************************************/
        const int DEPTH_LIMIT = 10;
        #region GAME_STATE_TREE_NODE
        /****************************************
        * A gameState is a node in the gameTree *
        ****************************************/
        class GameState
        {
            public int EvaluationScore { get; set; }
            /**********************************************************
            * currentPlayer is the player who will make the next move *
            **********************************************************/
            public int CurrentPlayer { get; private set; }
            /************************************************************************
            * Move is an array (x, y) representing the Board entry that was changed *
            *      to get from the parent gameState to the present GameState        *
            ************************************************************************/
            public int[] Move { get; private set; }
            /***********************************************
            * board is the state of the board at this node *
            ***********************************************/
            public Board GameBoard { get; private set; }
            /***********************************************************************************
            * parent is the previous gameState. Every node except the root has a unique parent *
            ***********************************************************************************/
            public GameState Parent { get; private set; }
            /**********************************************************
            * The children of a node are all the possible GameStates  *
            *      the currentPlayer's valid moves can lead too       *
            **********************************************************/
            public List<GameState> Children { get; set; }
            /*****************************************************************************
            * IsTerminalState is true if this node is a GameState where the game is over *
            *****************************************************************************/
            public bool IsTerminalState
            {
                get
                {
                    if (GameBoard.isFull()) return true;
                    else return false;
                }
            }
            /******************************************************************************************
            * GameState Constructor (only the root of a gameTree has null Parent and Move properties) *
            ******************************************************************************************/
            public GameState(Board GameBoard, int CurrentPlayer, int[] Move = null, GameState Parent = null)
            {
                if (GameBoard == null)
                    throw new ArgumentNullException("Failed to find an instance of Board class to initialize the gameState.");

                if (CurrentPlayer != COMPUTER && CurrentPlayer != OPONENT)
                    throw new ArgumentException(String.Format("Invalid token!\ncurrentPlayer = {0} (currentPlayer must equal {1} or {2}).", CurrentPlayer, COMPUTER, OPONENT));

                this.GameBoard = GameBoard;
                this.CurrentPlayer = CurrentPlayer;
                this.Move = Move;
                this.Parent = Parent;
            }
        }
        #endregion
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
            root = new GameState(initialBoardState, COMPUTER);
        }
        /******************************************************************
        * returns a two element array (x, y) representing an optimum move *
        ******************************************************************/
        public int[] Decision()
        {
            /*******************************************************************************
            * The children of the root node is the set of moves the computer can pick from *
            *******************************************************************************/
            /*
            int optimumScore = MaxValue(root, infinity, -infinity, 0);
            
            // Find the first children of the root with an optimumScore

            GameState optimumState = root.Children.Find(gameState => gameState.EvaluationScore == optimumScore);
            return optimumState.Move;
            
            ^ this is more or less how it is actually going to work, now we need to actually implement
            the evaluation function before we can test it

            The evaluation function should return a value between -infinity and infinity
            
            + something for EACH 4-in-a-line for computer
            + something for EACH 3-in-a-line for computer
            + something for EACH 2-in-a-line for computer

            Negative scores for opponent, i.e.
            -something for EACH of the opponent's 4-in-a-line, 3-in-a-line and 2-in-a-line
            */

            // This is a place holder, it just picks a random
            // move from the children of the initial game state
            root.Children = GetChildren(root);
            Random random = new Random();
            int randomIndex = random.Next(root.Children.Count);
            return root.Children[randomIndex].Move;
        }
        /**************************************************************************
        *        currentBoard: the current state (or node) being explored         *
        * returns the minimum possible value min can chose from the current state *
        *       (the evaluation score of an optimum node for the oponent)         *
        **************************************************************************/
            int MaxValue(GameState gameState, int alpha, int beta, int depth)
        {
            if (gameState.IsTerminalState || depth == DEPTH_LIMIT)
                return Evaluation(gameState);

            gameState.Children = GetChildren(gameState);

            while (gameState.Children.Any())
            {
                alpha = Math.Max(alpha, MinValue(gameState.Children.First(), alpha, beta, depth + 1));

                if (alpha >= beta) return beta;

                gameState.Children.RemoveAt(0);
            }
            return alpha;
        }
        /**************************************************************************
        *        currentBoard: the current state (or node) being explored         *
        * returns the minimum possible value min can chose from the current state *
        *       (the evaluation score of an optimum node for the oponent)         *
        **************************************************************************/
        int MinValue(GameState gameState, int alpha, int beta, int depth)
        {
            if (gameState.IsTerminalState || depth == DEPTH_LIMIT)
                return Evaluation(gameState);

            gameState.Children = GetChildren(gameState);

            while (gameState.Children.Any())
            {
                beta = Math.Min(beta, MaxValue(gameState.Children.First(), alpha, beta, depth + 1));

                if (beta <= alpha) return alpha;

                gameState.Children.RemoveAt(0);
            }
            return beta;
        }
        /****************************************************************
        * assigns a numerical value to any given gameState, high values *
        *      are good for the computer and bad for the oponent        *
        ****************************************************************/
        int Evaluation(GameState gamesState)
        {
            // This is a place holder, it returns the
            // score advantage of the COMPUTER at the GameState
            int oponentScore = gamesState.GameBoard.getPlayerOneScore();
            int computerScore = gamesState.GameBoard.getPlayerTwoScore();
            return computerScore - oponentScore;
        }
        /******************************************************************************************
        * getChildren returns the list all the possible moves that can follow any given gameState *
        ******************************************************************************************/
        List<GameState> GetChildren(GameState gameState)
        {
            int[] move = null;
            Board newBoard = null;
            GameState newGameState = null;
            List<GameState> children = new List<GameState>();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    /******************************************************
                    *     If the board entry (i, j) is free, then the     *
                    *   current player can place their token in that cell *
                    ******************************************************/
                    if (gameState.GameBoard.isFree(i, j))
                    {
                        move = new int[2] { i, j };
                        newBoard = new Board(gameState.GameBoard);
                        newBoard.updateBoard(i, j, gameState.CurrentPlayer);

                        if (gameState.CurrentPlayer == COMPUTER)
                            newGameState = new GameState(newBoard, OPONENT, move, gameState);

                        else if (gameState.CurrentPlayer == OPONENT)
                            newGameState = new GameState(newBoard, COMPUTER, move, gameState);

                        children.Add(newGameState);
                    }
                }
            }
            return children;
        }
    }
}
