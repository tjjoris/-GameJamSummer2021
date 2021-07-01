using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Display;

namespace FreeEscape.Damage
{
    public class Debris : MonoBehaviour, I_ExplosionReaction
    {
        [SerializeField] private bool resistantDebris;
        [SerializeField] private ProgressShader shader;
        [SerializeField] private float timeToVaporize = 1000f;

        
        public void HitByExplosion(BombExplosion _explosion)
        {
            if ((_explosion.BigExplosion && resistantDebris) || (!resistantDebris))
            {
                if (shader)
                {
                    shader.ApplyShaderEffect(timeToVaporize);
                }
                Destroy(gameObject, timeToVaporize);
            }
        }
    }
}
