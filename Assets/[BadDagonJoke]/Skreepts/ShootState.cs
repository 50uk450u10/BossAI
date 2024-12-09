using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dagonite
{
    public class ShootState : BaseState
    {
        [SerializeField] GameObject projectile;

        public ShootState(StateMachine m) : base(m)
        {
        }

        override public void EnterState()
        {
            if(machine.Mroom.bossHealth.GetCurrentHealth() > 3)
            {
                machine.Mroom.StartCoroutine(machine.Mroom.FireProjectile());
            }
            else
            {
                machine.Mroom.StartCoroutine(machine.Mroom.FireProjectile2());
            }
        }

        override public void UpdateState()
        {
            machine.ChangeState(new TeleportState(machine));
        }

        override public void ExitState()
        {

        }
    }
}