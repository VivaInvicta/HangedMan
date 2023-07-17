using UnityEngine;

namespace HangedMan
{
    public abstract class UIController<TModel, TView>
        where TModel : UIModel 
        where TView : UIView
    {
        protected readonly TModel model;
        protected readonly TView view;

        public UIController(TModel model, TView view)
        {
            this.model = model;
            this.view = view;
        }

        public void Initialize()
        {
            model?.Initialize();
            view?.Initialize();

            InitializeInternal();
        }

        public void Release()
        {
            model?.Release();
            view?.Release();

            ReleaseInternal();
        }

        protected virtual void InitializeInternal()
        {  }

        protected virtual void ReleaseInternal()
        {  }
    }
}