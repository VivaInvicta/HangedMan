using System;
using System.Collections.Generic;
using System.Linq;

namespace HangedMan
{
    public class AnswerHandlerModel : UIModel
    {
        public event Action AllLettersRevealed;
        public event Action<char> LetterRevealed;

        private readonly string word;
        private int revealedLettersCount = 0;

        private List<char> revealedLetters;

        public string Word => word;
        
        public AnswerHandlerModel(WordProvider wordProvider) 
        {
            word = wordProvider.PickedWord;
            revealedLetters = new List<char>();
        }

        public void HandleKeyPressed(char key)
        {
            if (word.Contains(key) && !revealedLetters.Contains(key))
            {
                LetterRevealed?.Invoke(key);

                revealedLetters.Add(key);
                revealedLettersCount += word.Count(letter => letter == key);

                if (revealedLettersCount >= word.Length)
                {
                    AllLettersRevealed?.Invoke();
                }
            }
        }
    }
}