using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random.Classes
{
    public class Rand
    {
        private static System.Random _random;

        public static int GetRandomNumber(int min, int max)
        {
            if (_random == null)
                _random = new System.Random();

            return _random.Next(min, max);
        }
    }
}
