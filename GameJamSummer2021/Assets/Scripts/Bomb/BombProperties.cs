using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Damage;

namespace FreeEscape.Bomb
{
    public class BombProperties : MonoBehaviour, I_ExplosionDamageReaction, I_TriggerExplosion, I_AbilityProperties, I_CanDetonate
    {
        [SerializeField] private float timeTillExplode = 3.7f;
        [SerializeField] private GameObject bombExplosionPrefab;
        [SerializeField] private bool explosionsDetonate = true;
        [SerializeField] private float _launchVelocity;
        public float launchVelocity { get{ return _launchVelocity; } }
        [SerializeField] private float _cooldown;
        public float cooldown { get{ return _cooldown; } }
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public SpriteRenderer spriteRenderer { get{ return _spriteRenderer; } }
        [SerializeField] private Animator _animator;
        public Animator animator { get{ return _animator; } }
        [SerializeField] private AudioClip _launchAudioClip;
        public AudioClip launchAudioClip { get{ return _launchAudioClip; } }
        [SerializeField] private bool _frontLaunch;
        public bool FrontLaunch { get{ return _frontLaunch; } }

        [SerializeField] private Sprite _iconArmed;
        public Sprite IconArmed { get { return _iconArmed; } }

        [SerializeField] private Sprite _iconDisarmed;
        public Sprite IconDisarmed { get { return _iconDisarmed; } }

        private bool isOnCooldown = false;
        
        
                
        IEnumerator Start()
        {
            if (timeTillExplode > 0)
            {
                yield return new WaitForSeconds(timeTillExplode);
                Detonate();
            }
        }

        IEnumerator DoCooldown()
        {
            isOnCooldown = true;
            yield return new WaitForSeconds(_cooldown);
            isOnCooldown = false;
        }

        public bool IsOnCoolDown()
        {
            return isOnCooldown;
        }

        public void Detonate()
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
            if (explosionsDetonate)
            { Detonate(); }
        }
    }
}
