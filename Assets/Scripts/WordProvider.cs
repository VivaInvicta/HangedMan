using System.Collections.Generic;
using UnityEngine;

namespace HangedMan
{
    public class WordProvider
    {
        private readonly List<string> remainingWords;
        private string pickedWord;

        public string PickedWord => pickedWord;

        public WordProvider(GameConfiguration configuration)
        {
            remainingWords = configuration.AvailableWords;
        }

        public string PickNextRandomWord()
        {
            var wordNumber = Random.Range(0, remainingWords.Count);
            var word = remainingWords[wordNumber];
            remainingWords.RemoveAt(wordNumber);

            return word;
        }
    }
}