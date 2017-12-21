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

            var dir = Rand.GetRandomNumber(0, 2);

            if (dir == (int)Enums.Direction.Row)
            {
                // Row
                var randomRow = Rand.GetRandomNumber(0, _grid.Height);

                var originalRow = randomRow;
                var exitLoop = false;

                do
                {
                    var canInsert = CanInsert(Enums.Direction.Row, randomRow, text);

                    // When it can't insert try the next row, moving back to the beginning when it hits the end of the rows.
                    if (!canInsert)
                        randomRow = randomRow + 1 > _grid.Height - 1 ? 0 : randomRow + 1;

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
                var randomCol = Rand.GetRandomNumber(0, _grid.Width);

                var originalCol = randomCol;
                var exitLoop = false;

                do
                {
                    var canInsert = CanInsert(Enums.Direction.Column, randomCol, text);

                    // When it can't insert try the next row, moving back to the beginning when it hits the end of the rows.
                    if (!canInsert)
                        randomCol = randomCol + 1 > _grid.Width - 1 ? 0 : randomCol + 1;

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

                var spaces = GetSuitableSpaces(dir, pos, value);//.EmptySpaces;

                // Check if there is any free space that can fit the word.
                if (value.Length > spaces.EmptySpaces)
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

                var spaces = GetSuitableSpaces(dir, pos, value);//.EmptySpaces;

                // Check if there is any free space that can fit the word.
                if (value.Length > spaces.EmptySpaces)
                {
                    return false;
                }

                return true;
            }
        }

        private InsertionSpace GetSuitableSpaces(Enums.Direction dir, int pos, string word)
        {
            var emptySpace = GetEmptyConsecSpace(dir, pos, word.Length);
            var joinedSpace = GetJoinedSpace(dir, pos, word);

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

                num = 1;

                if (num == 0)
                    return emptySpace;
                else
                    return joinedSpace;
            }

            return new InsertionSpace(-1,0,0, Enums.InsertionSpaceType.Empty);
        }

        private JoinedInsertionSpace GetJoinedSpace(Enums.Direction dir, int pos, string word)
        {
            var validatedEntries = new List<JoinedInsertionSpace>();

            if (dir == Enums.Direction.Row)
            {
                // Get list of letters in row and letters in word.
                // If there are matching letters, then we try to place the word so that the letters cross over.
                // Check each tile the new word will go on and verify if space is empty or value matches with letter going on it.

                var currentLetters = new List<TileData>();

                for (var i = 0; i < _grid.Width; i++)
                {
                    var tile = _grid.GridData[pos][i];

                    if (!string.IsNullOrEmpty(tile.Value))
                    {
                        currentLetters.Add(new TileData(tile.Value, i));
                    }
                }

                if (currentLetters.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < currentLetters.Count; i++)
                {
                    var matchingLetterIndex = -1;

                    // Looping in case of the same letter appearing multiple times in the word.
                    do
                    {
                        matchingLetterIndex = word.IndexOf(currentLetters[i].Value, matchingLetterIndex + 1, StringComparison.Ordinal);

                        if (matchingLetterIndex == -1)
                            break;

                        var startingPoint = currentLetters[i].Position - matchingLetterIndex;

                        if (startingPoint < 0)
                            continue;

                        if (startingPoint + word.Length > _grid.Width)
                            continue;

                        var wordValidated = true;

                        // Check each space to see if it fits.
                        for (int q = startingPoint, w = 0; q < word.Length - 1; q++, w++)
                        {
                            var tile = _grid.GridData[pos][q];

                            if (string.IsNullOrEmpty(tile.Value)) continue;
                            if (tile.Value == word[w].ToString()) continue;
                            wordValidated = false;
                            break;
                        }

                        if (wordValidated)
                        {
                            validatedEntries.Add(new JoinedInsertionSpace(startingPoint, word.Length));
                        }

                    } while (true);
                }
            }
            else
            {
                // Get list of letters in row and letters in word.
                // If there are matching letters, then we try to place the word so that the letters cross over.
                // Check each tile the new word will go on and verify if space is empty or value matches with letter going on it.

                var currentLetters = new List<TileData>();

                for (var i = 0; i < _grid.Height; i++)
                {
                    var tile = _grid.GridData[i][pos];

                    if (!string.IsNullOrEmpty(tile.Value))
                    {
                        currentLetters.Add(new TileData(tile.Value, i));
                    }
                }

                if (currentLetters.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < currentLetters.Count; i++)
                {
                    var matchingLetterIndex = -1;

                    // Looping in case of the same letter appearing multiple times in the word.
                    do
                    {
                        matchingLetterIndex = word.IndexOf(currentLetters[i].Value, matchingLetterIndex + 1, StringComparison.Ordinal);

                        if (matchingLetterIndex == -1)
                            break;

                        var startingPoint = currentLetters[i].Position - matchingLetterIndex;

                        if (startingPoint < 0)
                            continue;

                        if (startingPoint + word.Length > _grid.Height)
                            continue;

                        var wordValidated = true;

                        // Check each space to see if it fits.
                        for (int q = startingPoint, w = 0; q < word.Length - 1; q++, w++)
                        {
                            var tile = _grid.GridData[q][pos];

                            if (string.IsNullOrEmpty(tile.Value)) continue;
                            if (tile.Value == word[w].ToString()) continue;
                            wordValidated = false;
                            break;
                        }

                        if (wordValidated)
                        {
                            validatedEntries.Add(new JoinedInsertionSpace(startingPoint, word.Length));
                        }

                    } while (true);
                }
            }

            if (validatedEntries.Count == 0)
                return null;

            var rand = new System.Random();

            return validatedEntries[Rand.GetRandomNumber(0, validatedEntries.Count)];
        }

        private ConsecEmptyInsertionSpace GetEmptyConsecSpace(Enums.Direction dir, int pos, int wordLength)
        {
            var values = new List<ConsecEmptyInsertionSpace>();

            if (dir == Enums.Direction.Row)
            {
                var maxCount = 0;
                
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
                        values.Add(new ConsecEmptyInsertionSpace(startPoint, maxCount, wordLength));

                        maxCount = 0;
                        startPoint = i + 1;
                    }
                }

                if (wordLength <= maxCount)
                {
                    values.Add(new ConsecEmptyInsertionSpace(startPoint, maxCount, wordLength));
                }
            }
            else
            {
                var maxCount = 0;
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
                        values.Add(new ConsecEmptyInsertionSpace(startPoint, maxCount, wordLength));

                        maxCount = 0;
                        startPoint = i + 1;
                    }
                }

                if (wordLength <= maxCount)
                {
                    values.Add(new ConsecEmptyInsertionSpace(startPoint, maxCount, wordLength));
                }
            }

            if (values.Count == 0)
                return null;

            return values.OrderByDescending(csv => csv.EmptySpaces).First();
        }

        private bool PerformInsert(Enums.Direction dir, int pos, string value)
        {
            if (dir == Enums.Direction.Row)
            {
                var startingPosition = GetSuitableSpaces(dir, pos, value);

                for (int i = 0, q = startingPosition.GetStartPosition(true); i < value.Length; i++, q++)
                {
                    _grid.GridData[pos][q].SubmitText(value[i].ToString());
                }
            }
            else
            {
                var startingPosition = GetSuitableSpaces(dir, pos, value);

                for (int i = 0, q = startingPosition.GetStartPosition(true); i < value.Length; i++, q++)
                {
                    _grid.GridData[q][pos].SubmitText(value[i].ToString());
                }
            }

            return false;
        }
    }
}
