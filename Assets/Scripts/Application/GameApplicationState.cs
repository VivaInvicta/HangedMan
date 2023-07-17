using UnityEngine;

namespace HangedMan
{
    public class GameApplicationState : State
    {
        [SerializeField]
        private GameConfiguration configuration;

        [SerializeField]
        private KeyboardView keyboardView;

        [SerializeField]
        private AnswerHandlerView answerHandlerView;

        [SerializeField]
        private MistakesCounterView mistakesCounterView;

        [SerializeField]
        private State keyboardState;

        [SerializeField]
        private State restartState;

        private StateContext bottomPanelStateContext;

        protected override void InitializeInternal()
        {
            var wordProvider = new WordProvider(configuration);
            wordProvider.PickNextRandomWord();

            var availableLetters = configuration.AvailableLetters.ToCharArray();

            var keyboardModel = new KeyboardModel(availableLetters);
            var answerHandlerModel = new AnswerHandlerModel(wordProvider);
            var mistakesCounterModel = new MistakesCounterModel(configuration.MaxMistakesCount, wordProvider);

            var keyboardController = new KeyboardController(keyboardModel, keyboardView);
            var answerHandlerController = new AnswerHandlerController(answerHandlerModel, answerHandlerView, keyboardModel);
            var mistakesCounterController = new MistakesCounterController(mistakesCounterModel, mistakesCounterView, keyboardModel);

            keyboardController.Initialize();
            answerHandlerController.Initialize();
            mistakesCounterController.Initialize();

            bottomPanelStateContext = new StateContext();
            bottomPanelStateContext.SetState(keyboardState);
        }

        private void HandleWin()
        {
            bottomPanelStateContext.SetState(restartState);
        }

        private void HandleLose()
        {
            bottomPanelStateContext.SetState(restartState);
        }
    }
}