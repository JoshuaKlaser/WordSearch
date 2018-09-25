using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random.Classes
{
    public class WordData
    {
        public List<Point> Location { get; private set; }
        public string Word { get; private set; }

        public WordData(string word)
        {
            Location = new List<Point>();

            Word = word;
        }

        public void AssignNewLetter(int x, int y)
        {
            Location.Add(new Point(x, y));
        }
    }
}
