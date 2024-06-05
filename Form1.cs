using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
//using System.Timers;

namespace TetrisRemake
{
    public partial class Form1 : Form
    {
        private Tetrimino currentTetrimino;
        private readonly int boardWidth = 10;
        private readonly int boardHeight = 20;
        public int cellSize; // dynamic cell size
        private int[,] board; // 2d array of spaces
        //private bool isResizing = false; // prevent loops
        private GameLogic gameLogic;
        private System.Windows.Forms.Timer gameTimer;
        public Form1()
        {
            InitializeComponent();
            gameLogic = new GameLogic();
            gameTimer = new System.Windows.Forms.Timer
            {
                Interval = 200 // play speed
            };
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
            InitializeBoard();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            gameLogic.Update();
            BoardPanel.Invalidate(); // Force redraw
        }
        

        private void InitializeBoard()
        {
            board = new int[boardWidth, boardHeight];
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    board[x, y] = 0;
                }
            }
        }

        private void BoardPanel_Paint(object sender, PaintEventArgs e)
        {
            var board = gameLogic.GetBoard();
            var currentTetrimino = gameLogic.GetCurrentTetrimino();
            Graphics g = e.Graphics;

            // Teken het bord
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y] != 0)
                    {
                        g.FillRectangle(Brushes.Gray, x * 30, y * 30, 30, 30);
                        g.DrawRectangle(Pens.Black, x * 30, y * 30, 30, 30);
                    }
                }
            }

            // Teken de huidige Tetrimino
            for (int x = 0; x < currentTetrimino.Width; x++)
            {
                for (int y = 0; y < currentTetrimino.Height; y++)
                {
                    if (currentTetrimino.Shape[x, y] != 0)
                    {
                        int boardX = currentTetrimino.Position.X + x;
                        int boardY = currentTetrimino.Position.Y + y;
                        var r = new Random().Next(1, 80);
                        using SolidBrush brush = new(Color.FromArgb(r, r, r));
                        //g.FillRectangle(brush, boardX * 30, boardY * 30, 30, 30);
                        g.FillRectangle(Brushes.Yellow, boardX * 30, boardY * 30, 30, 30);
                        g.DrawRectangle(Pens.Black, boardX * 30, boardY * 30, 30, 30);
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    gameLogic.MoveTetriminoLeft();
                    break;
                case Keys.Right:
                    gameLogic.MoveTetriminoRight();
                    break;
                case Keys.Up:
                    gameLogic.RotateTetrimino();
                    break;
                case Keys.Down:
                    gameLogic.MoveTetriminoDown();
                    break;
            }
            BoardPanel.Invalidate();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CenterBoardPanel();
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            CenterBoardPanel();
            BoardPanel.Invalidate(); // Force drawing
        }
        private void CenterBoardPanel()
        {
            int panelWidth = GamePanel.Width;
            int panelHeight = GamePanel.Height;

            // Bereken de dynamische grootte van de cellen
            int maxCellSizeByWidth = panelWidth / boardWidth;
            int maxCellSizeByHeight = panelHeight / boardHeight;
            cellSize = Math.Min(maxCellSizeByWidth, maxCellSizeByHeight);

            // Bereken de grootte van de BoardPanel op basis van de celgrootte
            int boardWidthInPixels = cellSize * boardWidth;
            int boardHeightInPixels = cellSize * boardHeight;

            // Bereken de gecentreerde positie
            int startX = (panelWidth - boardWidthInPixels) / 2;
            int startY = (panelHeight - boardHeightInPixels) / 2;

            BoardPanel.Location = new Point(startX, startY);
            BoardPanel.Size = new Size(boardWidthInPixels, boardHeightInPixels);
        }

        private void GridPanel_Paint(object sender, PaintEventArgs e)
        {
            /*int cellSize = BoardPanel.Height / boardHeight;
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    var random = new Random();
                    int r = random.Next(1, 80);
                    Color c = Color.FromArgb(r, r, r);
                    using SolidBrush brush = new(c);
                    e.Graphics.FillRectangle(brush, x * cellSize, y * cellSize, cellSize, cellSize);
                }
            }*/
        }

    }
}
