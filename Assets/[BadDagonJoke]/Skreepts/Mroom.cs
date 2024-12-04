using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dagonite
{
    public class Mroom : MonoBehaviour
    {
        [SerializeField] GameObject player;
        public GameObject[] tpPosition;
        public Transform target;
        Rigidbody rb;
        bool invisible;
        int maxHealth = 100;
        int currHealth;
        int rangedDamage = 25;
        int meleeDamage = 50;
        int speed = 10;
        public bool playerInRange;
        StateMachine machine;
        //Vector3 distance;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            currHealth = maxHealth;
            invisible = false;
            machine = new StateMachine(this);
            machine.ChangeState(new IdleState(machine));
        }

        private void Update()
        {
            transform.LookAt(target);
            //distance = new Vector3(Vector3.Distance(player.transform.position, this.transform.position), Vector3.Distance(player.transform.position, this.transform.position), Vector3.Distance(player.transform.position, this.transform.position));
            float dist = Vector3.Distance(player.transform.position, rb.transform.position);
            if(dist <= 20 ) { playerInRange = true; }
            //Debug.Log(dist);
            machine.UpdateState();
        }
    }
}