using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

namespace Dagonite
{
    public class StateMachine : MonoBehaviour
    {
        UnityEvent ChangeStates;
        BaseState currState;

        void ChangeState(BaseState newState)
        {
            currState = newState;
        }
    }
}