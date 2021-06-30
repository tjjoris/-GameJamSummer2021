using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Damage
{
    public interface I_ExplosionReaction
    {
        void HitByExplosion(BombExplosion _explosion);
    }
}
