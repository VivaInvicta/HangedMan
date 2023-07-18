using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HangedMan
{
    public class WordProvider
    {
        private List<string> remainingWords;
        private GameConfiguration gameConfiguration;
        private string pickedWord;

        public string PickedWord => pickedWord;

        public WordProvider(GameConfiguration configuration)
        {
            gameConfiguration = configuration;
            GetWordsFromConfig();
        }

        public void PickNextRandomWord()
        {
            if (remainingWords.Count == 0) 
            {
                GetWordsFromConfig();
            }

            var wordNumber = Random.Range(0, remainingWords.Count);
            pickedWord = remainingWords[wordNumber];
            remainingWords.RemoveAt(wordNumber);
        }

        private void GetWordsFromConfig()
        {
            //ToList method here is to avoid removing elements from original list.
            remainingWords = gameConfiguration.AvailableWords.ToList();
        }
    }
}