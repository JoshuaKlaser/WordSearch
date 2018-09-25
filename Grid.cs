using Random.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random
{
    public class Grid
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        private GridBrain _brain;
        public List<List<GridTile>> GridData { get; private set; }
        private List<string> _wordsToUse;
        private List<SubmissionResponse> _wordData;

        public Grid(int height, int width)
        {
            Height = height;
            Width = width;

            CreateTiles();

            _wordsToUse = new List<string>();
            _brain = new GridBrain(this);
            _wordData = new List<SubmissionResponse>();
        }

        private void CreateTiles()
        {
            GridData = new List<List<GridTile>>(Height);

            for (int i = 0; i < Height; i++)
            {
                var row = new List<GridTile>(Width);

                for (int q = 0; q < Width; q++)
                {
                    row.Add(new GridTile(string.Empty));
                }

                GridData.Add(row);
            }
        }

        public void SubmitText(string text)
        {
            _wordsToUse.Add(text);
            //return _brain.SubmitText(text);
        }

        public void SubmitText(params string[] words)
        {
            foreach (var word in words)
            {
                _wordsToUse.Add(word);
            }
        }

        public bool GenerateGrid(int retryCount, bool fillWithLetters)
        {
            // Can't generate a grid if there's nothing there. Will flag as true since it didn't error out.
            if (_wordsToUse.Count == 0)
                return true;

            var orderedWords = _wordsToUse.OrderByDescending(w => w.Length);

            var tries = 0;
            var succeeded = true;

            do
            {
                tries++;
                foreach (var word in orderedWords)
                {
                    var submission = _brain.SubmitText(word);
                    succeeded = submission.Success;

                    _wordData.Add(submission);

                    if (!succeeded)
                    {
                        break;
                    }
                }

                if (succeeded)
                    break;

            } while (tries > retryCount);

            if (fillWithLetters)
                _brain.FillWithRandomLetters();

            return succeeded;
        }

        public bool CheckWord(string word)
        {
            var cleanedWord = word.Trim().ToLower();

            return _wordsToUse.Exists(w => w == word);
        }

        public List<Point> GetWordData(string word)
        {
            if (!CheckWord(word))
                return null;

            var wordData = _wordData.FirstOrDefault(wd => wd.Data.Word == word);

            return wordData.Data.Location;
        }
    }
}
