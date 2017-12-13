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
        private List<GridRow> _rows;
        private List<GridRow> _columns;

        public Grid(int height, int width)
        {
            Height = height;
            Width = width;

            _rows = new List<GridRow>(width);
            _columns = new List<GridRow>(height);

            CreateTiles();

            _brain = new GridBrain(this);
        }

        private void CreateTiles()
        {
            for (int i = 0; i < Height; i++)
            {
                _rows.Add(new GridRow(Width));
            }

            for (int i = 0; i < Width; i++)
            {
                _columns.Add(new GridRow(Height));
            }
        }

        public bool SubmitText(string text)
        {
            return _brain.SubmitText(text);
        }
    }
}
