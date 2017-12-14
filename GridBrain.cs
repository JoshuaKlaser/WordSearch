using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class GridBrain
    {
        private Grid _grid;

        public GridBrain(Grid grid)
        {
            _grid = grid;
        }

        public bool SubmitText(string text)
        {
            // random number to determine column or row
            var rand = new System.Random();

            var dir = rand.Next(0, 1);

            // random number to determine which row/column to try to enter text.

            if (dir == 0)
            {
                // Row
                var val = rand.Next(0, _grid.Width - 1);
            }
            else
            {
                // Column
                var val = rand.Next(0, _grid.Height - 1);
            }
        }

        private bool CanInsert(Enums.Direction dir, int pos, string value)
        {
            if (dir == Enums.Direction.Row)
            {
                if (value.Length > _grid.Width)
                {
                    return false;
                }
            }
        }

        private int GetMaxEmptyConsecSpace(Enums.Direction dir, int pos)
        {
            if (dir == Enums.Direction.Row)
            {
                var maxCount = 0;
                var finalCount = 0;

                foreach (var tile in _grid.Grid[pos])
                {
                    if (string.IsNullOrEmpty(tile.Value))
                    {
                        maxCount++;
                    }
                    else
                    {
                        finalCount = maxCount > finalCount ? maxCount : finalCount;
                        maxCount = 0
                    }
                }

                finalCount = maxCount > finalCount ? maxCount : finalCount;

                return finalCount;
            }
        }
    }
}
