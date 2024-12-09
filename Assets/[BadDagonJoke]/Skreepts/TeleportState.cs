using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dagonite
{
    public class TeleportState : BaseState
    {
        public float timeSinceTeleported;
        int teleportIndex;
        int previousPos;
        GameObject[] points;

        public TeleportState(StateMachine m) : base(m)
        {
        }

        override public void EnterState()
        {
            teleportIndex = Random.Range(1, 5);
            points = machine.Mroom.tpPosition;
        }

        override public void UpdateState()
        {
            timeSinceTeleported += Time.deltaTime;
            elapsed += Time.deltaTime;

            if (elapsed > 5)
            {
                if (machine.Mroom.timesSwitched < 5 && machine.Mroom.bossHealth.GetCurrentHealth() > 6)
                {
                    machine.ChangeState(new ShootState(machine));
                    machine.Mroom.timesSwitched++;
                    if(machine.Mroom.timesSwitched >= 5)
                    {
                        machine.Mroom.timesSwitched = 0;
                    }
                }
                else if (machine.Mroom.timesSwitched < 5 && machine.Mroom.bossHealth.GetCurrentHealth() <= 6 && machine.Mroom.bossHealth.GetCurrentHealth() > 3)
                {
                    machine.ChangeState(new MeleeState(machine));
                    machine.Mroom.timesSwitched++;
                    if(machine.Mroom.timesSwitched >= 5)
                    {
                        machine.Mroom.timesSwitched = 0;
                    }
                }
                else if(machine.Mroom.timesSwitched < 3 && machine.Mroom.bossHealth.GetCurrentHealth() <= 3)
                {
                    machine.Mroom.visibility.enabled = false;
                    machine.ChangeState(new ShootState(machine));
                    machine.Mroom.timesSwitched++;
                    if(machine.Mroom.timesSwitched >= 3)
                    {
                        machine.ChangeState(new MeleeState(machine));
                        machine.Mroom.timesSwitched = 0;
                    }
                }
            }
            if(machine.Mroom.bossHealth.GetCurrentHealth() > 3)
            {
                if(timeSinceTeleported > 1) { timeSinceTeleported = 0; Teleport(); }
            }
            else if (timeSinceTeleported > 0.5) {  timeSinceTeleported = 0; Teleport(); }
        }

        override public void ExitState()
        {
            
        }

        void Teleport()
        {
            //Debug.Log(teleportIndex);
            previousPos = teleportIndex;
            machine.Mroom.transform.position = points[teleportIndex - 1].transform.position;
            //Debug.Log(machine.Mroom.transform.position);
            teleportIndex = Random.Range(1, 5);
            while(teleportIndex == previousPos)
            {
                teleportIndex = Random.Range(1, 5);
            }
        }
    }
}