using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Bomb
{
    public class TriggerBombRadius : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            I_TriggerExplosion objectHit = collision.gameObject.GetComponent<I_TriggerExplosion>();
            if (objectHit != null)
            {
                objectHit.TriggerExplosionRange();
            }
        }

    }
}
