using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Damage;

namespace FreeEscape.Bomb
{
    public class BombProximityContact : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject objectHit = collision.gameObject;
            if (objectHit != null)
            {
                GetComponent<I_CanDetonate>().Detonate();
            }
        }
    }
}
