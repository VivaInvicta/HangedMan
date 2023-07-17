using System;
using UnityEngine;
using UnityEngine.UI;

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

    public class AnswerLetterView : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        public void SetLetter(char letter) 
        {
            text.text = letter.ToString();
        }

        public void SetLetterActive(bool isActive) 
        {
            text.gameObject.SetActive(isActive);
        }
    }
}