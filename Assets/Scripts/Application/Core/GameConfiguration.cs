using System.Collections.Generic;
using UnityEngine;

namespace HangedMan
{
    [CreateAssetMenu]
    public class GameConfiguration : ScriptableObject
    {
        [SerializeField]
        private List<string> availableWords;

        [SerializeField]
        private string availableLetters;

        [SerializeField]
        private int maxMistakesCount;

        public List<string> AvailableWords => availableWords;
        public int MaxMistakesCount => maxMistakesCount;
        public string AvailableLetters => availableLetters;
    }
}