using System;
using System.Linq;

namespace HangedMan
{
    public class AnswerHandlerModel : UIModel
    {
        public event Action AllLettersRevealed;
        public event Action<char> LetterRevealed;

        private readonly string word;
        private int revealedLettersCount = 0;

        public string Word => word;
        
        public AnswerHandlerModel(WordProvider wordProvider) 
        {
            word = wordProvider.PickedWord;
        }

        public void HandleKeyPressed(char key)
        {
            if (word.Contains(key))
            {
                LetterRevealed?.Invoke(key);

                revealedLettersCount += word.Count(letter => letter == key);

                if (revealedLettersCount >= word.Length)
                {
                    AllLettersRevealed?.Invoke();
                }
            }
        }
    }
}