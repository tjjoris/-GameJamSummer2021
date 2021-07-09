using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Damage;

namespace FreeEscape.Bomb
{
    public class BombProximityContact : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            I_ExplosionDamageReaction objectHit = collision.gameObject.GetComponent<I_ExplosionDamageReaction>();
            if (objectHit != null)
            {
                GetComponent<BombProperties>().Detonate();
            }
        }
    }
}
