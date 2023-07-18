namespace HangedMan
{
    public class GameController : UIController<GameModel, GameView>
    {
        private KeyboardModel keyboardModel;
        private WinsCounterModel winsCounterModel;

        private StateContext bottomPanelStateContext;

        private MistakesCounterController mistakesCounterController;
        private AnswerHandlerController answerHandlerController;
        private KeyboardController keyboardController;
        private WinsCounterController winsCounterController;

        public GameController(GameModel model, GameView view) : base(model, view)
        { }

        protected override void InitializeInternal()
        {
            var availableLetters = model.Configuration.AvailableLetters.ToCharArray();

            keyboardModel = new KeyboardModel(availableLetters);
            keyboardController = new KeyboardController(keyboardModel, view.KeyboardView);
            keyboardController.Initialize();

            winsCounterModel = new WinsCounterModel();
            winsCounterController = new WinsCounterController(winsCounterModel, view.WinsCounterView);
            winsCounterController.Initialize();

            bottomPanelStateContext = new StateContext();
            bottomPanelStateContext.SetState(view.KeyboardState);

            view.RestartButtonPressed += HandleRestartPressed;

            RestartGame();
        }

        protected override void ReleaseInternal()
        {
            view.RestartButtonPressed -= HandleRestartPressed;

            keyboardController?.Release();
            answerHandlerController?.Release();
            mistakesCounterController?.Release();
            winsCounterController?.Release();
        }

        private void RestartGame()
        {
            mistakesCounterController?.Release();
            answerHandlerController?.Release();

            model.WordProvider.PickNextRandomWord();

            var answerHandlerModel = new AnswerHandlerModel(model.WordProvider);
            var mistakesCounterModel = new MistakesCounterModel(model.Configuration.MaxMistakesCount, model.WordProvider);

            answerHandlerModel.AllLettersRevealed += HandleWin;
            mistakesCounterModel.MaxMistakesCountAchieved += HandleLose;

            answerHandlerController = new AnswerHandlerController(answerHandlerModel, view.AnswerHandlerView, keyboardModel);
            mistakesCounterController = new MistakesCounterController(mistakesCounterModel, view.MistakesCounterView, keyboardModel);

            answerHandlerController.Initialize();
            mistakesCounterController.Initialize();

            bottomPanelStateContext?.SetState(view.KeyboardState);
        }

        private void HandleWin()
        {
            bottomPanelStateContext?.SetState(view.RestartState);
            view.SetAfterWinTextActive();
            winsCounterModel?.HandleWin();
        }

        private void HandleLose()
        {
            bottomPanelStateContext?.SetState(view.RestartState);
            view.SetAfterLoseTextActive();
            winsCounterModel?.HandleLose();
        }

        private void HandleRestartPressed()
        {
            RestartGame();
        }
    }
}