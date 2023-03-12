﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BlockT : Blok
    {
        private readonly Pozycja[][] bloczki = new Pozycja[][]
        {
            new Pozycja[] { new(0,1), new(1,0), new(1,1), new(1,2) },
            new Pozycja[] { new(0,1), new(1,1),new(1,2), new(2,1) },
            new Pozycja[] { new(1,0), new(1,1), new(1,2), new(2,1) },
            new Pozycja[] { new(0,1), new(1,0), new(1,1), new(2,1) }
        };

        public override int Id => 6;
        protected override Pozycja StartOffset => new Pozycja(0, 3);
        protected override Pozycja[][] Bloczki => bloczki;
    }
}
