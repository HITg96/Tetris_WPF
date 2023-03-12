using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameState
    {
        private Blok currentBlock;

        public Blok CurrentBlock
        {
            get => currentBlock;
            private set { currentBlock = value; currentBlock.Reset(); 
            
                for(int i=0; i<2; i++)
                {
                    currentBlock.Move(0, 1);

                    if (!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }
            }
        }

        public GraSiat GraSiat { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }
        public int Score { get; private set; }
        public Blok HeldBlock { get; private set; }
        public bool CanHold { get; private set; }

        public GameState()
        {
            GraSiat = new GraSiat(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetUpdate();
            CanHold = true;
        }

        private bool BlockFits()
        {
            foreach(Pozycja p in CurrentBlock.PositionTile())
            {
                if(!GraSiat.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            return true;
        }

        public void HoldBlock()
        {
            if (!CanHold)
            {
                return;
            }

            if(HeldBlock == null)
            {
                HeldBlock = currentBlock;
                CurrentBlock = BlockQueue.GetUpdate();
            }
            else
            {
                Blok tmp = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = tmp;
            }
            CanHold = false;
        }

        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }

        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }

        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        private bool IsGameOver()
        {
            return !(GraSiat.IsRowempty(0) && GraSiat.IsRowempty(1));
        }

        private void PlaceBlock()
        {
            foreach(Pozycja p in CurrentBlock.PositionTile())
            {
                GraSiat[p.Row, p.Column] = CurrentBlock.Id;
            }

           Score += GraSiat.ClearAllrows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetUpdate();
                CanHold = true;
            }
        }

        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }

        private int TileDropDistance(Pozycja p)
        {
            int drop = 0;

            while(GraSiat.IsEmpty(p.Row + drop + 1, p.Column))
            {
                drop++;
            }
            return drop;
        }

        public int BlockDropDistance()
        {
            int drop = GraSiat.Rows;

            foreach(Pozycja p in CurrentBlock.PositionTile())
            {
                drop = System.Math.Min(drop, TileDropDistance(p));
            }

            return drop;
        }

        public void DropBlock()
        {
            CurrentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
        }
    }
}
