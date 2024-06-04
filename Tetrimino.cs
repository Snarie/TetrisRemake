using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisRemake
{
    internal abstract class Tetrimino
    {
        public int[,] Shape { get; protected set; }
        public int Width { get { return Shape.GetLength(0); } }
        public int Height { get { return Shape.GetLength(1); } }
        public Point Position { get; set; }

        public Tetrimino()
        {
            Position = new Point(0, 0);
        }

        public void Rotate()
        {
            int[,] rotatedShape = new int[Height, Width];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    rotatedShape[y, Width - x - 1] = Shape[x, y];

                }
            }
            Shape = rotatedShape;
        }

    }

    internal class ITetrimino : Tetrimino
    {
        public ITetrimino()
        {
            Shape = new int[,]
            {
                { 1, 1, 1, 1 }
            };
        }
    }
    internal class OTetrimino : Tetrimino
    {
        public OTetrimino()
        {
            Shape = new int[,]
            {
                { 1, 1 },
                { 1, 1, }
            };
        }
    }
    internal class TTetrimino : Tetrimino
    {
        public TTetrimino()
        {
            Shape = new int[,]
            {
                { 0, 1, 0 },
                { 1, 1, 1 }
            };
        }
    }
    internal class STetrimino : Tetrimino
    {
        public STetrimino()
        {
            Shape = new int[,]
            {
                { 0, 1, 1 },
                { 1, 1, 0 }
            };
        }
    }
    internal class ZTetrimino : Tetrimino
    {
        public ZTetrimino()
        {
            Shape = new int[,]
            {
                { 1, 1, 0 },
                { 0, 1, 1 }
            };
        }
    }
    internal class JTetrimino : Tetrimino
    {
        public JTetrimino()
        {
            Shape = new int[,]
            {
                { 1, 0, 0 },
                { 1, 1, 1 }
            };
        }
    }
    internal class LTetrimino : Tetrimino
    {
        public LTetrimino()
        {
            Shape = new int[,]
            {
                { 0, 0, 1 },
                { 1, 1, 1 }
            };
        }
    }
}
