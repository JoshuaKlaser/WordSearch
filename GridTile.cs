using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class GridTile
    {
        public string Value { get; private set; }

        public GridTile(string value)
        {
            Value = value;
        }

        public void SubmitText(string text)
        {
            Value = text;
        }
    }
}
