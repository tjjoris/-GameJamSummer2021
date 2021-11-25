using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Damage;
using Sirenix.OdinInspector;

namespace FreeEscape.Bomb
{
    public class BombProperties : MonoBehaviour, I_ExplosionDamageReaction, I_TriggerExplosion, I_AbilityProperties, I_CanDetonate
    {
        [HorizontalGroup("Split", 88)]
        [VerticalGroup("Split/Sprites")]
        [BoxGroup("Split/Sprites/Armed", centerLabel:true), PreviewField(80), HideLabel]
        [SerializeField] private Sprite _iconArmed;
        public Sprite IconArmed { get { return _iconArmed; } }

        [BoxGroup("Split/Sprites/Disarmed", centerLabel:true), PreviewField(80), HideLabel]
        [SerializeField] private Sprite _iconDisarmed;
        public Sprite IconDisarmed { get { return _iconDisarmed; } }

        [VerticalGroup("Split/Attributes")]
        [BoxGroup("Split/Attributes/Explosion Rules"), LabelWidth(120)]
        [SerializeField] private float timeTillExplode = 3.7f;

        [BoxGroup("Split/Attributes/Explosion Rules"), LabelWidth(120)]
        [SerializeField] private float _cooldown;
        public float cooldown { get{ return _cooldown; } }

        [VerticalGroup("Split/Attributes"), LabelWidth(120)]
        [SerializeField] private bool explosionsDetonate = true;

        [VerticalGroup("Split/Attributes"), LabelWidth(120)]
        [SerializeField] private float _launchVelocity;
        public float launchVelocity { get{ return _launchVelocity; } }

        [VerticalGroup("Split/Attributes"), LabelWidth(120)]
        [SerializeField] private bool _frontLaunch;
        public bool FrontLaunch { get{ return _frontLaunch; } }

        [Space(10)]
        [VerticalGroup("Split/Attributes"), LabelWidth(120)]
        [SerializeField] private GameObject bombExplosionPrefab;

        [FoldoutGroup("Split/Attributes/Setup")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        public SpriteRenderer spriteRenderer { get{ return _spriteRenderer; } }

        [FoldoutGroup("Split/Attributes/Setup")]
        [SerializeField] private Animator _animator;
        public Animator animator { get{ return _animator; } }

        [FoldoutGroup("Split/Attributes/Setup")]
        [SerializeField] private AudioClip _launchAudioClip;
        public AudioClip launchAudioClip { get{ return _launchAudioClip; } }
        


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
