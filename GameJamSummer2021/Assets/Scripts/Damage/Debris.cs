using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Display;
using FreeEscape.Core;
using FreeEscape.Audio;

namespace FreeEscape.Damage
{
    [RequireComponent(typeof(DebrisEvent))]
    public class Debris : MonoBehaviour, I_ExplosionDamageReaction
    {
        [SerializeField] private float _hitPoints;
        public float HitPoints { get{ return _hitPoints; } }
        [SerializeField] private float _currentHitPoints;
        
        [SerializeField] private bool resistantDebris;
        [SerializeField] private ProgressShader innerShader;
        [SerializeField] private AnimationCurve innerCurve;
        [SerializeField] private ProgressShader outerShader;
        [SerializeField] private AnimationCurve outerCurve;

        [SerializeField] private float timeToVaporizeMin = 0.38f;
        [SerializeField] private float timeToVaporizeMax = 1.62f;
        private AudioPlayerManager audioPlayerManager;
        private DebrisEvent debrisEvent;

        private void Start() 
        {
            debrisEvent = this.GetComponent<DebrisEvent>();
            audioPlayerManager = FindObjectOfType<AudioPlayerManager>();
            _currentHitPoints = _hitPoints;
        }
 
        public void HitByExplosion(BombExplosion _explosion)
        {
            if ((_explosion.BigExplosion && resistantDebris) || (!resistantDebris))
            {
                TakeDamage(_explosion);
            }
        }

        public void TriggerExplosionRange()
        {
            //TODO: Dust particle effect.
        }

        private void TakeDamage(BombExplosion _explosion)
        {
            _currentHitPoints -= _explosion.Damage;

            float timeToVaporize = Random.Range(timeToVaporizeMin, timeToVaporizeMax);
                
            if (outerShader)
            {
                outerShader.ApplyShaderEffect((timeToVaporize), (outerCurve.Evaluate(ProgressShaderToPercent())));
            }

            if (innerShader)
            {
                innerShader.ApplyShaderEffect(timeToVaporize, (innerCurve.Evaluate(ProgressShaderToPercent())));
            }

            if (ProgressShaderToPercent() >= 1)
            {
                debrisEvent.AlertEventWatchers();    
                Destroy(gameObject, timeToVaporize);
                FindObjectOfType<ScoreTracker>().AddDebrisScore(_hitPoints);
            }
        }

        private float ProgressShaderToPercent()
        {
            float percentile = 1 - ( _currentHitPoints / _hitPoints );
            percentile = Mathf.Clamp(percentile, 0.01f, 1f);
            return percentile;
        }
    }
}
