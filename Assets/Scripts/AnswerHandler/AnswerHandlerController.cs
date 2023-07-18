using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HangedMan
{
    public class AnswerHandlerController : UIController<AnswerHandlerModel, AnswerHandlerView>
    {
        private readonly KeyboardModel keyboardModel;
        private Dictionary<AnswerLetterView, char> viewLettersDictionary;

        public AnswerHandlerController(AnswerHandlerModel model, AnswerHandlerView view, KeyboardModel keyboardModel)
            : base(model, view)
        {
            this.keyboardModel = keyboardModel;
        }

        protected override void InitializeInternal()
        {
            CreateLetterViews();

            keyboardModel.KeyPressed += OnKeyPressed;
            model.LetterRevealed += RevealLetter;
        }

        protected override void ReleaseInternal()
        {
            DestroyLetterViews();

            keyboardModel.KeyPressed -= OnKeyPressed;
            model.LetterRevealed -= RevealLetter;
        }

        private void OnKeyPressed(char key)
        {
            model.HandleKeyPressed(key);
        }

        private void RevealLetter(char letter)
        {
            var viewsToReveal = viewLettersDictionary.Where(view => view.Value == letter);

            foreach (var viewLetterPair in viewsToReveal) 
            {
                viewLetterPair.Key.SetLetterActive(true);
            }
        }
        
        private void DestroyLetterViews()
        {
            foreach (var viewLetterPair in viewLettersDictionary)
            {
                var view = viewLetterPair.Key.gameObject;
                Object.Destroy(view);
            }
            viewLettersDictionary.Clear();
        }

        private void CreateLetterViews()
        {
            var answerWord = model.Word;
            viewLettersDictionary = new Dictionary<AnswerLetterView, char>();

            for (var i = 0; i < answerWord.Length; i++) 
            {
                var letter = answerWord[i];
                var instance = Object.Instantiate(view.LetterViewPrefab);

                instance.SetLetter(letter);
                instance.SetLetterActive(false);

                instance.transform.SetParent(view.LettersContainer, false);

                viewLettersDictionary.Add(instance, letter);
            }
        }
    }
}