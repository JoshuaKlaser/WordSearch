using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class JoinedInsertionSpace : InsertionSpace
    {
        public JoinedInsertionSpace(int startPoint, int wordLength)
            : base(startPoint, wordLength, wordLength, Enums.InsertionSpaceType.Joined)
        {
        }

        public override int GetStartPosition(bool useRandomThreshold)
        {
            return StartPoint;
        }
    }
}
