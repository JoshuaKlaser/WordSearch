using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class GridBrain
    {
        private Grid _grid;

        public GridBrain(Grid grid)
        {
            _grid = grid;
        }

        public bool SubmitText(string text)
        {
            var finalResult = false;

            // random number to determine column or row
            var rand = new System.Random();

            // random number to determine which row/column to try to enter text.
            var dir = rand.Next(0, 2);

            if (dir == (int)Enums.Direction.Row)
            {
                // Row
                var randomRow = rand.Next(0, _grid.Height - 1);

                var originalRow = randomRow;
                var exitLoop = false;

                do
                {
                    var canInsert = CanInsert(Enums.Direction.Row, randomRow, text);

                    // When it can't insert try the next row, moving back to the beginning when it hits the end of the rows.
                    if (!canInsert)
                        randomRow = randomRow + 1 > _grid.Width ? 0 : randomRow + 1;

                    finalResult = canInsert;

                    // Exit loop if it can insert, or if we've tried every row and gone back to the original row.
                    exitLoop = canInsert || originalRow == randomRow;

                } while (!exitLoop);

                // If validation passes, then insert it.
                if (finalResult)
                {
                    PerformInsert(Enums.Direction.Row, randomRow, text);
                }
            }
            else
            {
                // Column
                var randomCol = rand.Next(0, _grid.Height - 1);

                var originalCol = randomCol;
                var exitLoop = false;

                do
                {
                    var canInsert = CanInsert(Enums.Direction.Column, randomCol, text);

                    // When it can't insert try the next row, moving back to the beginning when it hits the end of the rows.
                    if (!canInsert)
                        randomCol = randomCol + 1 > _grid.Width ? 0 : randomCol + 1;

                    finalResult = canInsert;

                    // Exit loop if it can insert, or if we've tried every row and gone back to the original row.
                    exitLoop = canInsert || originalCol == randomCol;

                } while (!exitLoop);

                // If validation passes, then insert it.
                if (finalResult)
                {
                    PerformInsert(Enums.Direction.Column, randomCol, text);
                }
            }

            return finalResult;
        }

        private bool CanInsert(Enums.Direction dir, int pos, string value)
        {
            if (dir == Enums.Direction.Row)
            {
                // Check if text value length is greater than actual space.
                if (value.Length > _grid.Width)
                {
                    return false;
                }

                // Check if there is any free space that can fit the word.
                if (value.Length > GetMaxEmptyConsecSpace(dir, pos, value.Length).EmptySpaces)
                {
                    return false;
                }

                return true;
            }
            else
            {
                // Check if text value length is greater than actual space.
                if (value.Length > _grid.Height)
                {
                    return false;
                }

                // Check if there is any free space that can fit the word.
                if (value.Length > GetMaxEmptyConsecSpace(dir, pos, value.Length).EmptySpaces)
                {
                    return false;
                }

                return true;
            }
        }

        private ConsecSpaceValue GetMaxEmptyConsecSpace(Enums.Direction dir, int pos, int wordLength)
        {
            if (dir == Enums.Direction.Row)
            {
                var maxCount = 0;
                var values = new List<ConsecSpaceValue>();
                var startPoint = 0;

                for (var i = 0; i < _grid.GridData[pos].Count; i++)
                {
                    var tile = _grid.GridData[pos][i];

                    if (string.IsNullOrEmpty(tile.Value))
                    {
                        maxCount++;
                    }
                    else
                    {
                        values.Add(new ConsecSpaceValue(startPoint, maxCount, wordLength));

                        maxCount = 0;
                        startPoint = i + 1;
                    }
                }

                values.Add(new ConsecSpaceValue(startPoint, maxCount, wordLength));

                return values.OrderByDescending(csv => csv.EmptySpaces).First();
            }
            else
            {
                var maxCount = 0;
                var values = new List<ConsecSpaceValue>();
                var startPoint = 0;

                for (var i = 0; i < _grid.Height; i++)
                {
                    var tile = _grid.GridData[i][pos];

                    if (string.IsNullOrEmpty(tile.Value))
                    {
                        maxCount++;
                    }
                    else
                    {
                        values.Add(new ConsecSpaceValue(startPoint, maxCount, wordLength));

                        maxCount = 0;
                        startPoint = i + 1;
                    }
                }

                values.Add(new ConsecSpaceValue(startPoint, maxCount, wordLength));

                return values.OrderByDescending(csv => csv.EmptySpaces).First();
            }
        }

        private bool PerformInsert(Enums.Direction dir, int pos, string value)
        {
            if (dir == Enums.Direction.Row)
            {
                var startingPosition = GetMaxEmptyConsecSpace(dir, pos, value.Length);

                for (int i = 0, q = startingPosition.GetStartPosition(true); i < value.Length; i++, q++)
                {
                    _grid.GridData[pos][q].SubmitText(value[i].ToString());
                }
            }
            else
            {
                var startingPosition = GetMaxEmptyConsecSpace(dir, pos, value.Length);

                for (int i = 0, q = startingPosition.GetStartPosition(true); i < value.Length; i++, q++)
                {
                    _grid.GridData[q][pos].SubmitText(value[i].ToString());
                }
            }

            return false;
        }
    }
}
