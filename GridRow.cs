using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class GridRow
    {
        public int Limit { get; private set; }

        private List<GridTile> _row;

        public GridRow(int limit)
        {
            Limit = limit;

            _row = new List<GridTile>(limit);

            for (int i = 0; i < limit; i++)
            {
                _row.Add(new GridTile(string.Empty));
            }
        }
    }
}
