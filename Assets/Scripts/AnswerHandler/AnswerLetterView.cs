using UnityEngine;
using UnityEngine.UI;

namespace HangedMan
{
    public class AnswerLetterView : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        public void SetLetter(char letter) 
        {
            text.text = letter.ToString();
        }

        public void SetLetterActive(bool isActive) 
        {
            text.gameObject.SetActive(isActive);
        }
    }
}