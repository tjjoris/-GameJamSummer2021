using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Damage;

namespace FreeEscape.Collision
{
    public class BombCollider : MonoBehaviour
    {

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debris debris = collision.gameObject.GetComponent<Debris>();
            if (debris != null)
            {
                //make debris explode
                Debug.Log("bomb collided with debris.");
                debris.HitByBomb();
                Destroy(gameObject, 1f);
            }
        }
    }
}
