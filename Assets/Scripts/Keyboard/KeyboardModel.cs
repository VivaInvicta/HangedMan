using System;
using System.Linq;

namespace HangedMan
{
    public class KeyboardModel : UIModel
    {
        public event Action<char> KeyPressed;

        private readonly char[] keyboardSymbols;

        public char[] KeyboardSymbols => keyboardSymbols;

        public KeyboardModel(char[] keyboardSymbols)
        {
            this.keyboardSymbols = keyboardSymbols;
        }

        public void HandleKeyPressed(char key) => KeyPressed?.Invoke(key);
    }
}