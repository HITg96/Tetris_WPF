using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Blok
    {
        protected abstract Pozycja[][] Bloczki { get; }
        protected abstract Pozycja StartOffset { get; }
        public abstract int Id { get; }

        private int rotationState;
        private Pozycja offset;

        public Blok()
        {
            offset = new Pozycja(StartOffset.Row, StartOffset.Column);
        }

        public IEnumerable<Pozycja> PositionTile() //Enumerator to mechanizm pozwalający na poruszanie się po kolekcji i zwracanie aktualnej pozycji w kolekcji.
        {
            foreach (Pozycja p in Bloczki[rotationState])
            {
                yield return new Pozycja(p.Row + offset.Row, p.Column + offset.Column); //yield return: aby podać następną wartość w iteracji
            }
        }

        public void RotateCW()//Clockwise
        {
            rotationState = (rotationState + 1) % Bloczki.Length;
        }

        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Bloczki.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
