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
            I_ExplosionDamageReaction objectHit = collision.gameObject.GetComponent<I_ExplosionDamageReaction>();
            if (objectHit != null)
            {
                GetComponent<BombProperties>().Detonate();
            }
        }
    }
}
