using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class ConsecEmptyInsertionSpace : InsertionSpace
    {
        public ConsecEmptyInsertionSpace(int startPoint, int emptySpaces, int wordLength)
            : base(startPoint, emptySpaces, wordLength, Enums.InsertionSpaceType.Empty)
        {
        }

        public override int GetStartPosition(bool useRandomThreshold)
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
