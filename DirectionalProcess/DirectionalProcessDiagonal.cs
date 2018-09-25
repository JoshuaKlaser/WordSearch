using Random.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class DirectionalProcessDiagonal //: DirectionalProcess
    {
        public DirectionalProcessDiagonal(Grid grid)//:base(Enums.Direction.Diagonal, grid, false)
        {
            //var random = Rand.GetRandomNumber(0, 1);

            //if (random == 0)
            //{
            //    _startingLine = Enums.StartingLine.Row;
            //}
            //else
            //{
            //    _startingLine = Enums.StartingLine.Column;
            //}

            //random = Rand.GetRandomNumber(0, 1);

            //if (random == 0)
            //{
            //    _wordFlow = Enums.UniqueWordFlow.Left;
            //}
            //else
            //{
            //    _wordFlow = Enums.UniqueWordFlow.Right;
            //}

            //StartRowCol = GetRandomStartSection();
        }

        //protected override int GetRandomStartSection()
        //{
        //    //if (_startingLine == Enums.StartingLine.Row)
        //    //{
        //    //    return Rand.GetRandomNumber(0, _grid.Width);
        //    //}
        //    //else
        //    //{
        //    //    return Rand.GetRandomNumber(0, _grid.Height);
        //    //}

        //    throw new NotImplementedException();
        //}

        //public override List<ConsecEmptyInsertionSpace> GetEmptyConsecSpace(string word)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
