using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BlockO : Blok
    {
        private readonly Pozycja[][] bloczki = new Pozycja[][]
        {
            new Pozycja[] { new(0,0), new(0,1), new(1,0), new(1,1) }
        };

        public override int Id => 4;
        protected override Pozycja StartOffset => new Pozycja(0, 4);
        protected override Pozycja[][] Bloczki => bloczki;
    }
}
