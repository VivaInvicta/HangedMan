using UnityEngine;
using UnityEngine.UI;

namespace HangedMan
{
    public class MainMenuApplicationState : State
    {
        [SerializeField]
        private State nextState;

        [SerializeField]
        private Button startGameButton;

        protected override void InitializeInternal()
        {
            startGameButton.onClick.AddListener(() => stateContext.SetState(nextState));
        }

        protected override void ReleaseInternal()
        {
            startGameButton.onClick.RemoveAllListeners();
        }
    }
}