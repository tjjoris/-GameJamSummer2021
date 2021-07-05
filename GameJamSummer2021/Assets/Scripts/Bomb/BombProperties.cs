using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Damage;

namespace FreeEscape.Bomb
{
    public class BombProperties : MonoBehaviour, I_ExplosionDamageReaction, I_TriggerExplosion
    {
        [SerializeField] float timeTillExplode = 3.7f;
        [SerializeField] GameObject bombExplosionPrefab;
        [SerializeField] GameObject extraFuseExplosionPrefab;
        [SerializeField] private float _launchVelocity;
        public float launchVelocity { get{ return _launchVelocity; } set{ _launchVelocity = value; } }
        [SerializeField] private float _cooldown;
        public float cooldown { get{ return _cooldown; } set{ _cooldown = value; } }
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public SpriteRenderer spriteRenderer { get{ return _spriteRenderer; } set{ _spriteRenderer = value; } }
        [SerializeField] private Animator _animator;
        public Animator animator { get{ return _animator; } set{ _animator = value; } }
        [SerializeField] private AudioClip _launchAudioClip;
        public AudioClip launchAudioClip { get{ return _launchAudioClip; } set{ _launchAudioClip = value; } }
        
                
        IEnumerator Start()
        {
            if (timeTillExplode > 0)
            {
                yield return new WaitForSecondsRealtime(timeTillExplode);
                ExtraFuseExplosion();
                Detonate();
            }
        }
        private void Detonate()
        {
            Instantiate(bombExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        public void HitByExplosion(BombExplosion _explosion)
        {
            return;
        }

        public void TriggerExplosionRange()
        {
            Detonate();
        }
        private void ExtraFuseExplosion()
        {
            Instantiate(extraFuseExplosionPrefab, gameObject.transform.position, Quaternion.identity);
        }
    }
}
