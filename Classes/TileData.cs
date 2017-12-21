using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random.Classes
{
    public class TileData
    {
        public string Value { get; private set; }
        public int Position { get; private set; }
        public TileData(string value, int position)
        {
            Value = value;
            Position = position;
        }
    }
}
