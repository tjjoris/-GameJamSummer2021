using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Damage;

namespace FreeEscape
{
    public class ExplosionDamageRadius : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            BombExplosion bombExplosion = this.GetComponentInParent<BombExplosion>();
            
            I_ExplosionDamageReaction objectHit = collision.gameObject.GetComponent<I_ExplosionDamageReaction>();
            if (objectHit != null)
            {
                objectHit.HitByExplosion(bombExplosion);
            }
        }
    }
}
