using Random.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class DirectionalProcessRow : DirectionalProcess
    {
        public DirectionalProcessRow(Grid grid):base(Enums.Direction.Row, grid) { }

        protected override int GetRandomStartSection()
        {
            return Rand.GetRandomNumber(0, _grid.Width);
        }

        public override List<ConsecEmptyInsertionSpace> GetEmptyConsecSpace(string word)
        {
            var values = new List<ConsecEmptyInsertionSpace>();
            var maxCount = 0;
            var startPoint = 0;

            for (var i = 0; i < _grid.GridData[StartRowCol].Count; i++)
            {
                var tile = _grid.GridData[StartRowCol][i];

                if (string.IsNullOrEmpty(tile.Value))
                {
                    maxCount++;
                }
                else
                {
                    if (word.Length <= maxCount)
                    {
                        values.Add(new ConsecEmptyInsertionSpace(startPoint, maxCount, word.Length));
                    }

                    maxCount = 0;
                    startPoint = i + 1;
                }
            }

            if (word.Length <= maxCount)
            {
                values.Add(new ConsecEmptyInsertionSpace(startPoint, maxCount, word.Length));
            }

            return values;
        }

        public override List<JoinedInsertionSpace> GetJoinedSpace(string word)
        {
            // Get list of letters in row and letters in word.
            // If there are matching letters, then we try to place the word so that the letters cross over.
            // Check each tile the new word will go on and verify if space is empty or value matches with letter going on it.

            var validatedEntries = new List<JoinedInsertionSpace>();
            var currentLetters = new List<TileData>();

            for (var i = 0; i < _grid.Width; i++)
            {
                var tile = _grid.GridData[StartRowCol][i];

                if (!string.IsNullOrEmpty(tile.Value))
                {
                    currentLetters.Add(new TileData(tile.Value, i));
                }
            }

            if (currentLetters.Count == 0)
            {
                return validatedEntries;
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
                    for (int q = startingPoint, w = 0; w < word.Length; q++, w++)
                    {
                        var tile = _grid.GridData[StartRowCol][q];

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

            return validatedEntries;
        }

        public override WordData PerformInsert(InsertionSpace space, string word)
        {
            var wordData = new WordData(word);

            for (int i = 0, q = space.GetStartPosition(true); i < word.Length; i++, q++)
            {
                _grid.GridData[StartRowCol][q].SubmitText(word[i].ToString());
                wordData.AssignNewLetter(q, StartRowCol);
            }

            return wordData;
        }
    }
}
