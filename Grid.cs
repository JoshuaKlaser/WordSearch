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

        private GridBrain _brain;
        public List<List<GridTile>> GridData { get; private set; }

        public Grid(int height, int width)
        {
            Height = height;
            Width = width;

            CreateTiles();

            _brain = new GridBrain(this);
        }

        private void CreateTiles()
        {
            GridData = new List<List<GridTile>>(Height);

            for (int i = 0; i < Height; i++)
            {
                var row = new List<GridTile>(Width);

                for (int q = 0; q < Width; q++)
                {
                    row.Add(new GridTile(string.Empty));
                }

                GridData.Add(row);
            }
        }

        public bool SubmitText(string text)
        {
            return _brain.SubmitText(text);
        }
    }
}
