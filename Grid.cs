using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class Grid
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        public Grid(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
