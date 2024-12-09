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
            machine.Mroom.StartCoroutine(machine.Mroom.FireProjectile());
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