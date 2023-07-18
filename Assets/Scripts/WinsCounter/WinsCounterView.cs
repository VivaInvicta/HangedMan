using UnityEngine;
using UnityEngine.UI;

namespace HangedMan
{
    public class WinsCounterView : UIView
    {
        [SerializeField]
        private string unformattedText;

        [SerializeField]
        private Text text;

        public void SetCount(int winsCount, int loseCount)
        {
            text.text = string.Format(unformattedText, winsCount, loseCount);
        }
    }
}