using UnityEngine;
using UnityEngine.Events;

namespace Dagonite
{
    public class StateMachine
    {
        UnityEvent ChangeStates;
        BaseState currState;
        public Mroom Mroom;
        

        public StateMachine(Mroom m)
        {
            Mroom = m;
            
        }

        public void ChangeState(BaseState newState)
        {
            if (currState != null)
            {
                currState.ExitState();
            }
            currState = newState;
            currState.EnterState();
        }

        public void UpdateState()
        {
            if (currState != null)
            {
                currState.UpdateState();
            }
        }
    }
}