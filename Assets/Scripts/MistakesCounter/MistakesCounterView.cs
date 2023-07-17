using System;
using System.Collections.Generic;
using UnityEngine;

namespace HangedMan
{
    public class MistakesCounterView : UIView
    {
        [Tooltip("Numbers must starts from zero.")]
        [SerializeField]
        private MistakesStepView[] stepsView;

        public IEnumerable<MistakesStepView> StepViews => stepsView;
    }

    [Serializable]
    public class MistakesStepView
    {
        [SerializeField]
        private GameObject root;

        [SerializeField]
        private int stepNumber;

        public GameObject Root => root;
        public int StepNumber => stepNumber;
    }
}