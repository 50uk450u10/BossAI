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
            machine.Mroom.inAttackState = true;
            //Debug.Log("It's Time To D-d-d-d-d-d-d-d-d-d-d-uel!");
            machine.Mroom.visibility.enabled = false;
            machine.Mroom.attackBox.SetActive(true);
        }

        override public void UpdateState()
        {
            machine.Mroom.agent.SetDestination(machine.Mroom.player.transform.position);

            if (machine.Mroom.playerClose)
            {
                machine.ChangeState(new TeleportState(machine));
            }
        }

        override public void ExitState()
        {
            if(machine.Mroom.bossHealth.GetCurrentHealth() > 3)
            {
                machine.Mroom.visibility.enabled = true;
            }
            machine.Mroom.inAttackState = false;
        }
    }
}