using Random.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class DirectionalProcess
    {
        public Enums.Direction Direction { get; protected set; }
        public int StartRowCol { get; protected set; }

        protected int _startPointRow;
        protected int _startPointCol;
        protected Grid _grid;

        public DirectionalProcess(Enums.Direction dir, Grid grid, bool performStartSectionAtBase = true)
        {
            Direction = dir;
            _grid = grid;

            if (performStartSectionAtBase)
                StartRowCol = GetRandomStartSection();
        }

        public static int GetDirectionalProcessLimit()
        {
            // Using reflection, get the amount of classes that inherit from this class.
            return typeof(DirectionalProcess)
                .Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(DirectionalProcess)) && !t.IsAbstract)
                .Count();
        }

        public Enums.Direction GetNextDirection()
        {
            var amount = Enum.GetNames(typeof(Enums.Direction)).Length - 1;

            var nextVal = (int)Direction + 1;

            if (nextVal > amount)
                nextVal = 0;

            return (Enums.Direction)nextVal;
        }

        public virtual List<ConsecEmptyInsertionSpace> GetEmptyConsecSpace(string word) { throw new NotImplementedException(); }
        public virtual List<JoinedInsertionSpace> GetJoinedSpace(string word) { throw new NotImplementedException(); }
        public virtual WordData PerformInsert(InsertionSpace space, string word) { throw new NotImplementedException();  }

        protected virtual int GetRandomStartSection() { throw new NotImplementedException(); }
    }
}
