using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BlockQueue
    {
        private readonly Blok[] blocks = new Blok[]
        {
            new BlockI(),
            new BlockJ(),
            new BlockL(),
            new BlockO(),
            new blockS(),
            new BlockT(),
            new BlockZ()
        };


        private readonly Random random = new Random();

        public Blok NextBlock { get; private set; }

        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        private Blok RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        public Blok GetUpdate()
        {
            Blok blok = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (blok.Id == NextBlock.Id);
            return blok;
        }
    }
}
