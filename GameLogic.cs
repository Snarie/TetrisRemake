using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisRemake
{
    internal class GameLogic
    {
        private Tetrimino currentTetrimino;
        private int[,] board;
        private const int BoardWidth = 10;
        private const int BoardHeight = 20;

        public GameLogic()
        {
            board = new int[BoardWidth, BoardHeight];
            SpawnNewTetrimino();
        }

        private void SpawnNewTetrimino()
        {
            var random = new Random();
            int shapeIndex = random.Next(0, 7);
            switch (shapeIndex)
            {
                case 0:
                    currentTetrimino = new ITetrimino();
                    break;
                case 1:
                    currentTetrimino = new OTetrimino();
                    break;
                case 2:
                    currentTetrimino = new TTetrimino();
                    break;
                case 3:
                    currentTetrimino = new STetrimino();
                    break;
                case 4:
                    currentTetrimino = new ZTetrimino();
                    break;
                case 5:
                    currentTetrimino = new JTetrimino();
                    break;
                case 6:
                    currentTetrimino = new LTetrimino();
                    break;
            }
            currentTetrimino.Position = new Point(BoardWidth / 2 - currentTetrimino.Width / 2, 0);
        }

        public void Update()
        {
            MoveTetriminoDown();
        }

        public void MoveTetriminoDown()
        {
            currentTetrimino.Position = new Point(currentTetrimino.Position.X, currentTetrimino.Position.Y + 1);
            if (CheckCollision())
            {
                currentTetrimino.Position = new Point(currentTetrimino.Position.X, currentTetrimino.Position.Y - 1);
                MergeTetriminoToBoard();
                SpawnNewTetrimino();
            }
        }

        public void MoveTetriminoLeft()
        {
            currentTetrimino.Position = new Point(currentTetrimino.Position.X - 1, currentTetrimino.Position.Y);
            if (CheckCollision())
            {
                currentTetrimino.Position = new Point(currentTetrimino.Position.X + 1, currentTetrimino.Position.Y);
            }
        }

        public void MoveTetriminoRight()
        {
            currentTetrimino.Position = new Point(currentTetrimino.Position.X + 1, currentTetrimino.Position.Y);
            if (CheckCollision())
            {
                currentTetrimino.Position = new Point(currentTetrimino.Position.X - 1, currentTetrimino.Position.Y);
            }
        }

        public void RotateTetrimino()
        {
            currentTetrimino.Rotate();
            if (CheckCollision())
            {
                for (int i = 0; i < 3; i++) // rotate back 3 times to restore original orientation
                {
                    currentTetrimino.Rotate();
                }
            }
        }

        private bool CheckCollision()
        {
            for (int x = 0; x < currentTetrimino.Width; x++)
            {
                for (int y = 0; y < currentTetrimino.Height; y++)
                {
                    if (currentTetrimino.Shape[x, y] != 0)
                    {
                        int boardX = currentTetrimino.Position.X + x;
                        int boardY = currentTetrimino.Position.Y + y;

                        if (boardX < 0 || 
                            boardX >= board.GetLength(0) || 
                            boardY < 0 ||
                            boardY >= board.GetLength(1)-2) // Check if at the bottom (magic -2 for some reason)
                        {
                            return true;
                        }
                        if (board[boardX, boardY] != 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void MergeTetriminoToBoard()
        {
            for (int x = 0; x < currentTetrimino.Width; x++)
            {
                for (int y = 0; y < currentTetrimino.Height; y++)
                {
                    if (currentTetrimino.Shape[x, y] != 0)
                    {
                        int boardX = currentTetrimino.Position.X + x;
                        int boardY = currentTetrimino.Position.Y + y;
                        if (boardY >= 0)
                        {
                            board[boardX, boardY] = currentTetrimino.Shape[x, y];
                        }
                    }
                }
            }
            ClearFullRows();
        }

        private void ClearFullRows()
        {
            for (int y = BoardHeight - 1; y >= 0; y--)
            {
                bool isFullRow = true;
                for (int x = 0; x < BoardWidth; x++)
                {
                    if (board[x, y] == 0)
                    {
                        isFullRow = false;
                        break;
                    }
                }
                if (isFullRow)
                {
                    for (int row = y; row > 0; row--)
                    {
                        for (int col = 0; col < BoardWidth; col++)
                        {
                            board[col, row] = board[col, row - 1];
                        }
                    }
                    for (int col = 0; col < BoardWidth; col++)
                    {
                        board[col, 0] = 0;
                    }
                    y++; // Check the same row again since all rows moved down
                }
            }
        }

        public int[,] GetBoard()
        {
            return board;
        }

        public Tetrimino GetCurrentTetrimino()
        {
            return currentTetrimino;
        }
    }

}
