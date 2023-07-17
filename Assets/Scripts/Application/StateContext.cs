namespace HangedMan
{
    public class StateContext
    {
        private State currentState;

        public void SetState(State state, bool releaseLastState = true)
        {
            if (releaseLastState && currentState)
            {
                currentState.Release();
            }

            if (state)
            {
                currentState = state;
                currentState.Initialize(this);
            }
        }
    }
}