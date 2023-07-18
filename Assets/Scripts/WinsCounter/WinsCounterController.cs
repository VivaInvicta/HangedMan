namespace HangedMan
{
    public class WinsCounterController : UIController<WinsCounterModel, WinsCounterView>
    {
        public WinsCounterController(WinsCounterModel model, WinsCounterView view) : base(model, view)
        { }

        protected override void InitializeInternal()
        {
            view.SetCount(model.WinsCount, model.LoseCount);

            model.Updated += OnModelUpdated;
        }

        protected override void ReleaseInternal()
        {
            model.Updated -= OnModelUpdated;
        }

        private void OnModelUpdated()
        {
            view.SetCount(model.WinsCount, model.LoseCount);
        }
    }
}