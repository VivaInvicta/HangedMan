using UnityEngine;
using UnityEngine.UI;

namespace HangedMan
{
    public class KeyboardController : UIController<KeyboardModel, KeyboardView>
    {
        private UIView[] buttonViews;

        public KeyboardController(KeyboardModel model, KeyboardView view) : base(model, view)
        {  }

        protected override void InitializeInternal()
        {
            CreateButtonViews();
        }

        protected override void ReleaseInternal()
        {
            DestroyButtonViews();
        }

        private void OnButtonPressed(char associatedSymbol)
        {
            model.HandleKeyPressed(associatedSymbol);
        }

        private void DestroyButtonViews()
        {
            foreach (var button in buttonViews) 
            {
                button.Release();
                Object.Destroy(button);
            }
        }

        private void CreateButtonViews()
        {
            var prefab = view.ButtonPrefab;
            var allowedSymbols = model.KeyboardSymbols;

            buttonViews = new UIView[model.KeyboardSymbols.Length];

            for (var i = 0; i < allowedSymbols.Length; i++)
            {
                var associatedSymbol = allowedSymbols[i];
                var instance = Object.Instantiate(prefab);

                instance.transform.SetParent(view.ButtonsRoot);
                instance.SetText(associatedSymbol);

                instance.Initialize();

                instance.OnPressed += () => OnButtonPressed(associatedSymbol);

                buttonViews[i] = instance;
            }
        }
    }
}