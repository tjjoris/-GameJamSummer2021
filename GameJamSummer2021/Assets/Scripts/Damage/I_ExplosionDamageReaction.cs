using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Damage
{
    public interface I_ExplosionDamageReaction
    {
        void HitByExplosion(BombExplosion _explosion);
    }
}
