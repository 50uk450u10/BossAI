using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dagonite
{
    public class ShootState : BaseState
    {
        public ShootState(StateMachine m) : base(m)
        {
        }

        override public void EnterState()
        {

        }

        override public void UpdateState()
        {
            Debug.Log("Pew");
        }

        override public void ExitState()
        {

        }
    }
}