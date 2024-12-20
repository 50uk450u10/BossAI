using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Dagonite
{
    public class Mroom : MonoBehaviour
    {
        [SerializeField] public GameObject player;
        [SerializeField] GameObject projectile;
        [SerializeField] public GameObject attackBox;
        public GameObject[] tpPosition;
        public Transform target;
        [SerializeField] public Damageable bossHealth;
        //Rigidbody rb;
        public NavMeshAgent agent;
        bool invisible;
        //int maxHealth = 100;
        //int currHealth;
        //int rangedDamage = 25;
        //int meleeDamage = 50;
        //int speed = 10;
        public int timesSwitched = 0;
        public bool playerInRange;
        public bool playerClose;
        public bool inAttackState = false;
        StateMachine machine;
        public SkinnedMeshRenderer visibility;
        //Vector3 distance;

        private void Start()
        {
            //rb = GetComponent<Rigidbody>();
           //currHealth = maxHealth;
            invisible = false;
            machine = new StateMachine(this);
            machine.ChangeState(new IdleState(machine));
        }

        private void Update()
        {
            transform.LookAt(target);
            //distance = new Vector3(Vector3.Distance(player.transform.position, this.transform.position), Vector3.Distance(player.transform.position, this.transform.position), Vector3.Distance(player.transform.position, this.transform.position));
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if(dist <= 20 ) { playerInRange = true; }
            if(dist <= 2.5f) { playerClose = true; } else { playerClose = false; }
            //Debug.Log(dist);
            machine.UpdateState();

            if(bossHealth.GetCurrentHealth() <= 3 ) { FinalPhase(); }
        }

        public IEnumerator FireProjectile()
        {
            yield return new WaitForSeconds(3);
            GameObject p = Instantiate(projectile, transform.position, Quaternion.identity);
            p.transform.forward = transform.forward;
            yield return new WaitForSeconds(5);
            GameObject.Destroy(p);
        }

        public IEnumerator FireProjectile2()
        {
            machine.Mroom.visibility.enabled = true;
            yield return new WaitForSeconds(3);
            GameObject p = Instantiate(projectile, transform.position, Quaternion.identity);
            p.transform.forward = transform.forward;
            p.GetComponent<Rigidbody>().velocity = p.transform.forward * 5;
            yield return new WaitForSeconds(5);
            machine.Mroom.visibility.enabled = false;
            GameObject.Destroy(p);
        }

        public void Death()
        {
            Destroy(gameObject);
        }

        void FinalPhase()
        {
            agent.speed = 5;
        }

        public void StopFollow()
        {
            if(inAttackState)
                machine.ChangeState(new TeleportState(machine));
        }
    }
}