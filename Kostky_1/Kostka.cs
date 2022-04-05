using System;
using System.Collections.Generic;
using System.Text;

namespace Kostky_1
{
    public class Kostka
    {
        private int hodnota;
        public int Hodnota { get => hodnota; }

        public Kostka()
        {
            Hod();
        }
        public void Hod()
        {
            Random random = new Random();
            hodnota = random.Next(1, 7);

        }
    }
}
