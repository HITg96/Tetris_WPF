using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GraSiat
    {
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }


        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public GraSiat(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < Columns && c >= 0 && c < Columns;
        }

        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        public bool IsRowFull(int r)
        {
            for(int c = 0; c < Columns; c++)
            {
                if(grid[r, c] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsRowempty(int r)
        {
            for(int c = 0; c < Columns; c++)
            {
                if(grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        private void Clearrow(int r)
        {
            for(int c = 0; r < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        private void MoveRowDown(int r, int numRows)
        {
            for(int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        public int ClearAllrows()
        {
            int cleared = 0;

            for(int r = Rows-1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    Clearrow(r);
                    cleared++;
                }
                else if(cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }
            return cleared;
        }
    }
}
