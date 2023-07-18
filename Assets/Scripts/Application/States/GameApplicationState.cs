using UnityEngine;

namespace HangedMan
{
    public class GameApplicationState : State
    {
        [SerializeField]
        private GameConfiguration configuration;

        [SerializeField]
        private GameView gameView;

        private GameController gameController;

        protected override void InitializeInternal()
        {
            var gameModel = new GameModel(configuration);
            var gameController = new GameController(gameModel, gameView);
            gameController.Initialize();
        }

        protected override void ReleaseInternal()
        {
            gameController.Release();
        }
    }
}