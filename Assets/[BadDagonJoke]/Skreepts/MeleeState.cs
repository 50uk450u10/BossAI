using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Dagonite
{
    public class MeleeState : BaseState
    {
        public MeleeState(StateMachine m) : base(m)
        {
        }

        override public void EnterState()
        {
            Debug.Log("It's Time To D-d-d-d-d-d-d-d-d-d-d-uel!");
            machine.Mroom.visibility.enabled = false;
            machine.Mroom.agent.SetDestination(machine.Mroom.player.transform.position);
        }

        override public void UpdateState()
        {
            if (machine.Mroom.playerClose)
            {
                Debug.Log("Too Close");
                machine.ChangeState(new TeleportState(machine));
            }
        }

        override public void ExitState()
        {
            machine.Mroom.visibility.enabled = true;
        }
    }
}