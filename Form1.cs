using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TetrisRemake
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            InitializeBoard();
        }

        private readonly int boardWidth = 10;
        private readonly int boardHeight = 20;
        public int cellSize; // dynamic cell size
        private int[,] board; // 2d array of spaces
        private bool isResizing = false; // prevent loops

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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void GridPanel_Paint(object sender, PaintEventArgs e)
        {
            int cellSize = BoardPanel.Height / boardHeight;
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    var random = new Random();
                    int r = random.Next(1, 80);
                    //double v = Math.PI*(x + y/3)/5;
                    //double r = (int)((Math.Sin(v) + 1) * 40);
                    Color c = Color.FromArgb(r, r, r);
                    using SolidBrush brush = new(c);
                    e.Graphics.FillRectangle(brush, x * cellSize, y * cellSize, cellSize, cellSize);
                    //e.Graphics.DrawRectangle(Pens.White, x * cellSize, y * cellSize, cellSize, cellSize);
                }
            }
        }

    }
}
