using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Damage
{
    public class Debris : MonoBehaviour, I_ExplosionReaction
    {
        [SerializeField] private bool resistantDebris;

        public void HitByExplosion(BombExplosion _explosion)
        {
            if ((_explosion.BigExplosion && resistantDebris) || (!resistantDebris))
            Destroy(gameObject);
        }
    }
}
