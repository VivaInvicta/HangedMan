using System;
using UnityEngine;
using UnityEngine.UI;

namespace HangedMan
{
    public class GameView : UIView
    {
        public event Action RestartButtonPressed;

        [SerializeField]
        private KeyboardView keyboardView;

        [SerializeField]
        private AnswerHandlerView answerHandlerView;

        [SerializeField]
        private MistakesCounterView mistakesCounterView;

        [SerializeField]
        private WinsCounterView winsCounterView;

        [SerializeField]
        private State keyboardState;

        [SerializeField]
        private State restartState;

        [SerializeField]
        private Button restartButton;

        [SerializeField]
        private Text afterWinText;

        [SerializeField]
        private Text afterLoseText;

        public State KeyboardState => keyboardState;
        public State RestartState => restartState;

        public KeyboardView KeyboardView => keyboardView;
        public MistakesCounterView MistakesCounterView => mistakesCounterView;
        public AnswerHandlerView AnswerHandlerView => answerHandlerView;
        public WinsCounterView WinsCounterView => winsCounterView;

        public override void Initialize()
        {
            restartButton.onClick.AddListener(() => RestartButtonPressed?.Invoke());
        }

        public void SetAfterWinTextActive()
        {
            afterWinText.gameObject.SetActive(true);
            afterLoseText.gameObject.SetActive(false);
        }

        public void SetAfterLoseTextActive()
        {
            afterWinText.gameObject.SetActive(false);
            afterLoseText.gameObject.SetActive(true);
        }

        public override void Release()
        {
            restartButton.onClick.RemoveAllListeners();
        }
    }
}