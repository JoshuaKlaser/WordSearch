using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Random.Classes;

namespace Random
{
    internal sealed class GridBrain
    {
        private static System.Random _random = new System.Random();
        private Grid _grid;

        public GridBrain(Grid grid)
        {
            _grid = grid;
        }

        public SubmissionResponse SubmitText(string text)
        {
            SubmissionResponse finalResult = null;

            var dirProcess = GetRandomDirectionalProcess();
            var originalProcess = dirProcess;

            var retry = false;
            var retryCountMax = 3;
            var retryCount = 0;

            do
            {
                finalResult = SubmitTextInternal(dirProcess, _grid.Width, text);

                // If it inserted successfully, then do not retry.
                retry = !finalResult.Success;

                if (retry)
                {
                    var nextDir = dirProcess.GetNextDirection();

                    // If we've reached the original direction in the retry loop, then quit.
                    if (nextDir == originalProcess.Direction)
                    {
                        retryCount++;

                        if (retryCount == retryCountMax)
                            break;
                    }

                    dirProcess = GetDirectionProcess(nextDir);
                }

            } while (retry);

            return finalResult;
        }

        private DirectionalProcess GetRandomDirectionalProcess()
        {
            var dir = Rand.GetRandomNumber(0, DirectionalProcess.GetDirectionalProcessLimit());
            
            return GetDirectionProcess((Enums.Direction)dir);
        }

        private DirectionalProcess GetDirectionProcess(Enums.Direction dir)
        {
            DirectionalProcess dirProcess = null;

            switch ((Enums.Direction)dir)
            {
                case Enums.Direction.Row:
                    dirProcess = new DirectionalProcessRow(_grid);
                    break;
                case Enums.Direction.Column:
                    dirProcess = new DirectionalProcessColumn(_grid);
                    break;
                    //case Enums.Direction.Diagonal:
                    //    dirProcess = new DirectionalProcessDiagonal(_grid);
                    //break;
            }

            return dirProcess;
        }

        private SubmissionResponse SubmitTextInternal(DirectionalProcess dirProcess, int sizeValue, string text)
        {
            var finalResult = false;
            WordData wordData = null;

            var originalCol = dirProcess.StartRowCol;
            var iterateCol = originalCol;

            var exitLoop = false;

            InsertionSpace space = null;

            do
            {
                space = GetSuitableSpaces(dirProcess, iterateCol, text);

                var canInsert = space != null && text.Length <= space.EmptySpaces;

                // When it can't insert try the next row, moving back to the beginning when it hits the end of the rows.
                if (!canInsert)
                    iterateCol = iterateCol + 1 > sizeValue - 1 ? 0 : iterateCol + 1;

                finalResult = canInsert;

                // Exit loop if it can insert, or if we've tried every row and gone back to the original row.
                exitLoop = canInsert || originalCol == iterateCol;

            } while (!exitLoop);

            // If validation passes, then insert it.
            if (finalResult)
            {
                wordData = PerformInsert(dirProcess, text, space);
            }

            return new SubmissionResponse(finalResult, wordData);
        }

        private InsertionSpace GetSuitableSpaces(DirectionalProcess dirProcess, int pos, string word)
        {
            var emptySpace = GetEmptyConsecSpace(dirProcess, word);
            var joinedSpace = GetJoinedSpace(dirProcess, word);

            if (emptySpace == null && joinedSpace != null)
            {
                return joinedSpace;
            }

            if (emptySpace != null && joinedSpace == null)
            {
                return emptySpace;
            }

            if (emptySpace != null && joinedSpace != null)
            {
                var num = Rand.GetRandomNumber(0, 2);

                if (num == 0)
                    return emptySpace;
                else
                    return joinedSpace;
            }

            return new InsertionSpace(-1,0,0, Enums.InsertionSpaceType.Empty);
        }

        private JoinedInsertionSpace GetJoinedSpace(DirectionalProcess dirProcess, string word)
        {
            var validatedEntries = dirProcess.GetJoinedSpace(word);

            if (validatedEntries.Count == 0)
                return null;

            return validatedEntries[Rand.GetRandomNumber(0, validatedEntries.Count)];
        }

        private ConsecEmptyInsertionSpace GetEmptyConsecSpace(DirectionalProcess dirProcess, string word)
        {
            var values = dirProcess.GetEmptyConsecSpace(word);

            if (values.Count == 0)
                return null;

            return values.OrderByDescending(csv => csv.EmptySpaces).First();
        }

        private WordData PerformInsert(DirectionalProcess dirProcess, string value, InsertionSpace space)
        {
            return dirProcess.PerformInsert(space, value);
        }

        public void FillWithRandomLetters()
        {
            foreach (var row in _grid.GridData)
            {
                foreach (var tile in row)
                {
                    if (string.IsNullOrEmpty(tile.Value))
                    {
                        var randomNum = _random.Next(0, 26);
                        var randomAlpha = (char)('a' + randomNum);

                        tile.SubmitText(randomAlpha.ToString());
                    }
                }
            }
        }
    }
}
