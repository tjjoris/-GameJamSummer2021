using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Display;
using FreeEscape.Core;
using FreeEscape.Audio;

namespace FreeEscape.Damage
{
    public class Debris : MonoBehaviour, I_ExplosionReaction
    {
        [SerializeField] private bool resistantDebris;
        [SerializeField] private ProgressShader shader;
        [SerializeField] private float timeToVaporizeMin = 0.38f;
        [SerializeField] private float timeToVaporizeMax = 1.62f;
        private AudioPlayerManager audioPlayerManager;
        private DebrisEvent debrisEvent;

        private void Start() 
        {
            debrisEvent = this.GetComponent<DebrisEvent>();
            audioPlayerManager = FindObjectOfType<AudioPlayerManager>();
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
                //audioPlayerManager.PlayExplosion();
                debrisEvent.AlertEventWatchers();    
                Destroy(gameObject, timeToVaporize);
            }
        }
    }
}
