using System;
using UnityEngine;
using UnityEngine.UI;

namespace HangedMan
{
    public class KeyboardButtonView : UIView
    {
        public event Action OnPressed;

        [SerializeField]
        private Text buttonText;

        [SerializeField]
        private Button button;

        public override void Initialize()
        {
            button.onClick.AddListener(() => OnPressed?.Invoke());
        }

        public override void Release()
        {
            button.onClick.RemoveAllListeners();
        }

        public void SetText(char text)
        {
            buttonText.text = text.ToString();
        }
    }
}