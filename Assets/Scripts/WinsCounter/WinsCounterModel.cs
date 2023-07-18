using System;

namespace HangedMan
{
    public class WinsCounterModel : UIModel
    {
        public int LoseCount { get; private set; }
        public int WinsCount { get; private set; }

        public event Action Updated;

        public void HandleWin()
        {
            WinsCount++;
            Updated?.Invoke();
        }

        public void HandleLose()
        {
            LoseCount++;
            Updated?.Invoke();
        }
    }
}