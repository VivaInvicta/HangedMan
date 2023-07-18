using System.Linq;

namespace HangedMan
{
    public class MistakesCounterController : UIController<MistakesCounterModel, MistakesCounterView>
    {
        private readonly KeyboardModel keyboardModel;

        public MistakesCounterController(MistakesCounterModel model, MistakesCounterView view, KeyboardModel keyboardModel) 
            : base(model, view)
        {
            this.keyboardModel = keyboardModel;
        }

        protected override void InitializeInternal()
        {
            keyboardModel.KeyPressed += OnKeyPressed;
            model.MistakeMade += HandleMistakeMake;
        }

        protected override void ReleaseInternal()
        {
            keyboardModel.KeyPressed -= OnKeyPressed;
            model.MistakeMade -= HandleMistakeMake;

            DisableAllStepViews();
        }

        private void HandleMistakeMake()
        {
            ActivateCurrentStepView();
        }

        private void OnKeyPressed(char key)
        {
            model.HandleKeyPressed(key);

            ActivateCurrentStepView();
        }

        private void ActivateCurrentStepView() 
        {
            var stepNumber = model.MistakesCount;

            var stepView = view.StepViews.FirstOrDefault(view => view.StepNumber == stepNumber);
            if (stepView != null) 
            {
                stepView.Root.SetActive(true);
            }
        }

        private void DisableAllStepViews()
        {
            foreach (var stepView in view.StepViews) 
            {
                stepView.Root.SetActive(false);
            }
        }
    }
}