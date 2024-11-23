using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dagonite
{
    public class TeleportState : BaseState
    {
        public float timeSinceTeleported;

        public TeleportState(StateMachine m) : base(m)
        {
        }

        override public void EnterState()
        {

        }

        override public void UpdateState()
        {
            timeSinceTeleported += Time.deltaTime;
            elapsed += Time.deltaTime;
            if(elapsed > 5) { machine.ChangeState(new ShootState(machine)); }
            if(timeSinceTeleported > 1) { timeSinceTeleported = 0; Teleport(); }
        }

        override public void ExitState()
        {

        }

        void Teleport()
        {
            Debug.Log("Nyoom");
        }
    }
}