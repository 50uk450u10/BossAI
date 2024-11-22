using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dagonite
{
    public class Mroom : MonoBehaviour
    {
        int maxHealth = 100;
        int currHealth;

        private void Start()
        {
            currHealth = maxHealth;
        }
    }
}