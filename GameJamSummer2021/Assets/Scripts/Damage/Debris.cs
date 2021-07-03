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
        [SerializeField] private float timeToVaporizeMin = 0.38f;
        [SerializeField] private float timeToVaporizeMax = 1.62f;
        private AudioPlayerManager audioPlayerManger;

        private void Start()
        {
         audioPlayerManger = FindObjectOfType<AudioPlayerManager>();
        }

        public void HitByExplosion(BombExplosion _explosion)
        {
            if ((_explosion.BigExplosion && resistantDebris) || (!resistantDebris))
            {
                float timeToVaporize = Random.Range(timeToVaporizeMin, timeToVaporizeMax);
                
                if (shader)
                {
                    shader.ApplyShaderEffect(timeToVaporize);
                }
                
                Destroy(gameObject, timeToVaporize);
                //audioPlayerManger.PlayExplosion(1);
            }
        }
    }
}
