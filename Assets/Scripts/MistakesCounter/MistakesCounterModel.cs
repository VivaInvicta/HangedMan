using System;
using System.Linq;

namespace HangedMan
{
    public class MistakesCounterModel : UIModel
    {
        public event Action MistakeMade;
        public event Action MaxMistakesCountAchieved;

        private readonly int maxMistakesCount;
        private readonly string word;

        private int mistakesCount = 0;

        public int MistakesCount => mistakesCount;

        public MistakesCounterModel(int maxMistakesCount, WordProvider wordProvider)
        {
            this.maxMistakesCount = maxMistakesCount;
            this.word = wordProvider.PickedWord;
        }

        public void HandleKeyPressed(char key)
        {
            if (!word.Contains(key))
            {
                if (mistakesCount++ >= maxMistakesCount)
                {
                    MaxMistakesCountAchieved?.Invoke();
                }
                else
                {
                    MistakeMade?.Invoke();
                }
            }
        }
    }
}