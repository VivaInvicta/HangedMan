using System;
using UnityEngine;

namespace HangedMan
{
    public class KeyboardView : UIView
    {
        [SerializeField]
        private KeyboardButtonView buttonPrefab;

        [SerializeField]
        private Transform buttonsRoot;

        public KeyboardButtonView ButtonPrefab => buttonPrefab;
        public Transform ButtonsRoot => buttonsRoot;
    }
}