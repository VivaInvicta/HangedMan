using UnityEngine;

namespace HangedMan
{
    public class State : MonoBehaviour
    {
        [SerializeField]
        private GameObject root;

        protected StateContext stateContext;

        public void Initialize(StateContext context)
        {
            if (root) root.SetActive(true);

            stateContext = context;

            InitializeInternal();
        }

        public void Release()
        {
            if (root) root.SetActive(false);

            stateContext = null;

            ReleaseInternal();
        }

        protected virtual void InitializeInternal() { }

        protected virtual void ReleaseInternal() { }
    }
}