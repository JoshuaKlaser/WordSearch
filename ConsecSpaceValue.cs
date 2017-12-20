using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class ConsecSpaceValue
    {
        public int StartPoint { get; private set; }
        public int EmptySpaces { get; private set; }

        private readonly int _wordLength;

        public ConsecSpaceValue(int startPoint, int emptySpaces, int wordLength)
        {
            StartPoint = startPoint;
            EmptySpaces = emptySpaces;
            _wordLength = wordLength;
        }

        /// <summary>
        /// Collect the starting position to start the word.
        /// </summary>
        /// <param name="useRandomThreshold">Allow the starting position to be between randomly selected from multiple starting points if there is enough space.</param>
        /// <returns></returns>
        public int GetStartPosition(bool useRandomThreshold)
        {
            if (!useRandomThreshold)
            {
                return StartPoint;
            }
            else
            {
                var rand = new System.Random();
                var maxStartPoint = EmptySpaces == _wordLength ? StartPoint : EmptySpaces - _wordLength;

                if (maxStartPoint == StartPoint)
                    return StartPoint;

                return rand.Next(StartPoint, maxStartPoint + StartPoint);
            }
        }

    }
}
