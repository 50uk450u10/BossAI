using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dagonite
{
    public class Mroom : MonoBehaviour
    {
        Rigidbody rb;
        bool invisible;
        int maxHealth = 100;
        int currHealth;
        int rangedDamage = 25;
        int meleeDamage = 50;
        int speed = 10;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            currHealth = maxHealth;
            invisible = false;
        }
    }
}