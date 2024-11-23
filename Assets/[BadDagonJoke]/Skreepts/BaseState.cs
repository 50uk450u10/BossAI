using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dagonite
{
    public class BaseState
    {
        public StateMachine machine;
        public float elapsed;

        public BaseState(StateMachine m) { machine = m; }

        virtual public void EnterState()
        {

        }

        virtual public void UpdateState()
        {

        }

        virtual public void ExitState()
        {

        }
    }
}