using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dagonite
{
    public class IdleState : BaseState
    {
        public IdleState(StateMachine m) : base(m)
        {
        }

        override public void EnterState()
        {

        }

        override public void UpdateState()
        {
            if (machine.Mroom.playerInRange || machine.Mroom.bossHealth.GetCurrentHealth() <= 6)
            {
                machine.ChangeState(new TeleportState(machine));
            }
            //Debug.Log("Idle");
        }

        override public void ExitState()
        {

        }
    }
}