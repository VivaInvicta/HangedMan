using HangedMan;
using UnityEngine;

public class Application : MonoBehaviour
{
    [SerializeField]
    private State initialState;

    private void OnEnable()
    {
        var applicationStateContext = new StateContext();

        applicationStateContext.SetState(initialState);
    }
}
