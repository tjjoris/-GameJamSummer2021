using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Damage;

namespace FreeEscape.Bomb
{
    public class BombProperties : MonoBehaviour, I_ExplosionReaction
    {
        [SerializeField] float timeTillExplode = 3.7f;
        [SerializeField] GameObject bombExplosionPrefab;
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
        [SerializeField] private int explosionType;
        private AudioPlayerManager audioPlayerManager;
        
        
        
        
        IEnumerator Start()
        {
            audioPlayerManager = FindObjectOfType<AudioPlayerManager>();
            if (timeTillExplode > 0)
            {
                yield return new WaitForSecondsRealtime(timeTillExplode);
                Detonate();
            }
        }
        private void Detonate()
        {
            Instantiate(bombExplosionPrefab, gameObject.transform.position, Quaternion.identity);
            audioPlayerManager.PlayExplosion(explosionType);
            Destroy(gameObject);
        }

        public void HitByExplosion(BombExplosion _explosion)
        {
            Detonate();
        }
    }
}
