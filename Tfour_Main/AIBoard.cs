using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tfour_Main
{
    class AIBoard
    {
        #region BOARD_NETWORK_FIELDS
        const int NUM_ROW = 6, NUM_COL = 6;
        const int OPONENT = 1, COMPUTER = 2, EMPTY = 0;
        BoardNode[,] boardNetwork;
        const int upL = 0, up = 1, upR = 2;
        const int L = 3, R = 4;
        const int downL = 5, down = 6, downR = 7;
        List<BoardNode> possibleMoves;
        #endregion

        class BoardNode
        {
            public string ID;
            public int token, row, col;
            public double score;
            public BoardNode[] neighbors;

            public BoardNode(int token, string ID, int row, int col)
            {
                this.token = token;
                this.ID = ID;
                this.row = row;
                this.col = col;
                score = 0;
                neighbors = new BoardNode[8];
            }
        }

        public AIBoard(Board gameBoard)
        {
            boardNetwork = new BoardNode[NUM_ROW, NUM_COL];
            possibleMoves = new List<BoardNode>();
            CreateBoardNodes(gameBoard);
            ConnectBoardNodes();
            GeneratePossibleMoves();
        }

        public int[] Decision()
        {
            if (BoardIsEmpty())
            {
                return FirstMove();
            }
            return Move();
        }

        int[] FirstMove()
        {
            Random rand = new Random();
            int r, c;
            r = rand.Next(2, 4);
            c = rand.Next(2, 4);
            return new int[2] { r, c };
        }

        int[] Move()
        {
            CountAndAssignNodeScores();
            BoardNode optimumMove = FindHighestScoringNode();
            return new int[2] { optimumMove.row, optimumMove.col};
        }

        private BoardNode FindHighestScoringNode()
        {
            BoardNode highestNode = possibleMoves.First();
            foreach (var moveNode in possibleMoves)
            {
                if (moveNode.score > highestNode.score)
                {
                    highestNode = moveNode;
                }
            }
            return highestNode;
        }

        void CountAndAssignNodeScores()
        {
            int count = 0;

            foreach (var moveNode in possibleMoves)
            {
                count = CountComputerTokensDiagonalOne(moveNode);
                AssignOffensivePoints(moveNode, count);

                count = CountComputerTokensDiagonalTwo(moveNode);
                AssignOffensivePoints(moveNode, count);

                count = CountComputerTokensHorizontal(moveNode);
                AssignOffensivePoints(moveNode, count);

                count = CountComputerTokensVertical(moveNode);
                AssignOffensivePoints(moveNode, count);

                count = CountOpponentTokensDiagonalOne(moveNode);
                AssignDefensivePoints(moveNode, count);

                count = CountOpponentTokensDiagonalTwo(moveNode);
                AssignDefensivePoints(moveNode, count);

                count = CountOpponentTokensHorizontal(moveNode);
                AssignDefensivePoints(moveNode, count);

                count = CountOpponentTokensVertical(moveNode);
                AssignDefensivePoints(moveNode, count); 
            }
        }

        void AssignOffensivePoints(BoardNode moveNode, int count)
        {
            if (count == 1)
            {
                moveNode.score += 0.15;
            }
            else if (count == 2)
            {
                moveNode.score += 0.15;
            }
            else if (count == 3)
            {
                moveNode.score += 1.0;
            }
            else if (count == 4)
            {
                moveNode.score += 2.0;
            }
            else if (count == 5)
            {
                moveNode.score += 1;
            }
        }

        void AssignDefensivePoints(BoardNode moveNode, int count)
        {
            if (count == 1)
            {
                moveNode.score += 0.05;
            }
            else if (count == 2)
            {
                moveNode.score += 0.10;
            }
            else if (count == 3)
            {
                moveNode.score += 5.0;
            }
            else if (count == 4)
            {
                moveNode.score += 8.0;
            }
            else if (count == 5)
            {
                moveNode.score += 10.0;
            }
        }

        int CountComputerTokensDiagonalOne(BoardNode moveNode)
        {
            int count = 0;

            TraverseAndCountTokens(moveNode.neighbors[upL], upL, COMPUTER, ref count);
            TraverseAndCountTokens(moveNode.neighbors[downR], downR, COMPUTER, ref count);

            return count;
        }

        int CountComputerTokensDiagonalTwo(BoardNode moveNode)
        {
            int count = 0;

            TraverseAndCountTokens(moveNode.neighbors[upR], upR, COMPUTER, ref count);
            TraverseAndCountTokens(moveNode.neighbors[downL], downL, COMPUTER, ref count);

            return count;
        }

        int CountComputerTokensHorizontal(BoardNode moveNode)
        {
            int count = 0;

            TraverseAndCountTokens(moveNode.neighbors[L], L, COMPUTER, ref count);
            TraverseAndCountTokens(moveNode.neighbors[R], R, COMPUTER, ref count);

            return count;
        }

        int CountComputerTokensVertical(BoardNode moveNode)
        {
            int count = 0;

            TraverseAndCountTokens(moveNode.neighbors[up], up, COMPUTER, ref count);
            TraverseAndCountTokens(moveNode.neighbors[down], down, COMPUTER, ref count);

            return count;
        }

        int CountOpponentTokensDiagonalOne(BoardNode moveNode)
        {
            int count = 0;

            TraverseAndCountTokens(moveNode.neighbors[upL], upL, OPONENT, ref count);
            TraverseAndCountTokens(moveNode.neighbors[downR], downR, OPONENT, ref count);

            return count;
        }

        int CountOpponentTokensDiagonalTwo(BoardNode moveNode)
        {
            int count = 0;

            TraverseAndCountTokens(moveNode.neighbors[upR], upR, OPONENT, ref count);
            TraverseAndCountTokens(moveNode.neighbors[downL], downL, OPONENT, ref count);

            return count;
        }

        int CountOpponentTokensHorizontal(BoardNode moveNode)
        {
            int count = 0;

            TraverseAndCountTokens(moveNode.neighbors[L], L, OPONENT, ref count);
            TraverseAndCountTokens(moveNode.neighbors[R], R, OPONENT, ref count);

            return count;
        }

        int CountOpponentTokensVertical(BoardNode moveNode)
        {
            int count = 0;

            TraverseAndCountTokens(moveNode.neighbors[up], up, OPONENT, ref count);
            TraverseAndCountTokens(moveNode.neighbors[down], down, OPONENT, ref count);

            return count;
        }

        void TraverseAndCountTokens(BoardNode curNode, int direction, int TOKEN, ref int count)
        {
            if (curNode == null)
            {
                return;
            }

            if (curNode.token == TOKEN)
            {
                count++;
                TraverseAndCountTokens(curNode.neighbors[direction], direction, TOKEN, ref count);
            }

            return;
        }

        bool BoardIsEmpty()
        {
            for (int r = 0; r < NUM_ROW; r++)
            {
                for (int c = 0; c < NUM_COL; c++)
                {
                    if (boardNetwork[r, c].token != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        void GeneratePossibleMoves()
        {
            for (int r = 0; r < NUM_ROW; r++)
            {
                for (int c = 0; c < NUM_COL; c++)
                {
                    if (boardNetwork[r, c].token == EMPTY)
                    {
                        possibleMoves.Add(boardNetwork[r, c]);
                    }
                }
            }
        }

        void CreateBoardNodes(Board gameBoard)
        {
            int[,] boardMatrix = gameBoard.getGameMatrix();
            for (int r = 0; r < NUM_ROW; r++)
            {
                for (int c = 0; c < NUM_COL; c++)
                {
                    boardNetwork[r, c] = new BoardNode(boardMatrix[r, c], String.Format("({0}, {1})", r, c), r, c);
                }
            }
        }

        /**
         * Connects the nodes on the grid to their neighbors.
         */
        void ConnectBoardNodes()
        {
            for (int r = 0; r < NUM_ROW; r++)
            {
                for (int c = 0; c < NUM_COL; c++)
                {
                    /**
                     * If the node it's not in the first row then it has a neighbor above.
                     */
                    if (r > 0) boardNetwork[r, c].neighbors[up] = boardNetwork[r - 1, c];
                    /**
                     * If the node it's not in the last row then it has a neighbor below.
                     */
                    if (r < NUM_ROW - 1) boardNetwork[r, c].neighbors[down] = boardNetwork[r + 1, c];
                    /**
                     * If the node it's not in the leftmost column then it has a neighbor to the left.
                     */
                    if (c > 0) boardNetwork[r, c].neighbors[L] = boardNetwork[r, c - 1];
                    /**
                     * If the node it's not in the rightmost column then it has a neighbor to the right.
                     */
                    if (c < NUM_COL - 1) boardNetwork[r, c].neighbors[R] = boardNetwork[r, c + 1];

                    if ((r > 0 && r < NUM_ROW - 1) && (c > 0 && c < NUM_COL - 1))
                    {
                        boardNetwork[r, c].neighbors[upL] = boardNetwork[r - 1, c - 1];
                        boardNetwork[r, c].neighbors[upR] = boardNetwork[r - 1, c + 1];
                        boardNetwork[r, c].neighbors[downL] = boardNetwork[r + 1, c - 1];
                        boardNetwork[r, c].neighbors[downR] = boardNetwork[r + 1, c + 1];
                    }

                    if (r == 0 && (c > 0 && c < NUM_COL - 1))
                    {
                        boardNetwork[r, c].neighbors[downL] = boardNetwork[r + 1, c - 1];
                        boardNetwork[r, c].neighbors[downR] = boardNetwork[r + 1, c + 1];
                    }

                    if ((r > 0 && r < NUM_ROW - 1) && c == 0)
                    {
                        boardNetwork[r, c].neighbors[upR] = boardNetwork[r - 1, c + 1];
                        boardNetwork[r, c].neighbors[downR] = boardNetwork[r + 1, c + 1];
                    }

                    if (r == NUM_ROW - 1 && (c > 0 && c < NUM_COL - 1))
                    {
                        boardNetwork[r, c].neighbors[upL] = boardNetwork[r - 1, c - 1];
                        boardNetwork[r, c].neighbors[upR] = boardNetwork[r - 1, c + 1];
                    }

                    if ((r > 0 && r < NUM_ROW - 1) && c == 5)
                    {
                        boardNetwork[r, c].neighbors[upL] = boardNetwork[r - 1, c - 1];
                        boardNetwork[r, c].neighbors[downL] = boardNetwork[r + 1, c - 1];
                    }
                }
            }
            boardNetwork[0, 0].neighbors[downR] = boardNetwork[1, 1];
            boardNetwork[0, 5].neighbors[downL] = boardNetwork[1, 4];
            boardNetwork[5, 0].neighbors[upR] = boardNetwork[4, 1];
            boardNetwork[5, 5].neighbors[downL] = boardNetwork[4, 4];
        }
    }
}
