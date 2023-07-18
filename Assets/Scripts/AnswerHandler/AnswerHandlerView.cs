using System;
using UnityEngine;

namespace HangedMan
{
    public class AnswerHandlerView : UIView
    {
        [SerializeField]
        private AnswerLetterView letterViewPrefab;

        [SerializeField]
        private Transform lettersContainer;

        public AnswerLetterView LetterViewPrefab => letterViewPrefab;
        public Transform LettersContainer => lettersContainer;
    }
}