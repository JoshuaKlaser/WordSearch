using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class InsertionSpace
    {
        public int StartPoint { get; private set; }
        public int EmptySpaces { get; private set; }

        protected readonly int _wordLength;
        protected readonly Enums.InsertionSpaceType _type;

        public InsertionSpace(int startPoint, int emptySpaces, int wordLength, Enums.InsertionSpaceType spaceType)
        {
            StartPoint = startPoint;
            EmptySpaces = emptySpaces;
            _wordLength = wordLength;
            _type = spaceType;
        }

        /// <summary>
        /// Collect the starting position to start the word.
        /// </summary>
        /// <param name="useRandomThreshold">Allow the starting position to be between randomly selected from multiple starting points if there is enough space.</param>
        /// <returns></returns>
        public virtual int GetStartPosition(bool useRandomThreshold)
        {
            return -1;
        }

    }
}
