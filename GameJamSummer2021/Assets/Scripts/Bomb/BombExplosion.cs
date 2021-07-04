using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Damage;
using FreeEscape.Audio;

namespace FreeEscape
{
    public class BombExplosion : MonoBehaviour
    {
        [SerializeField] private bool thisIsBigExplosion;
        public bool BigExplosion { get { return thisIsBigExplosion; } set { thisIsBigExplosion = value; } }
        [SerializeField] private float _damage;
        public float Damage { get{ return _damage; } set{ _damage = value; } }
        private AudioPlayerManager audioPlayerManager;

        
        
        void Start()
        {
            audioPlayerManager = FindObjectOfType<AudioPlayerManager>();
            audioPlayerManager.PlayExplosion();
            Destroy(gameObject, 0.2f);
            }
  
        private void OnTriggerEnter2D(Collider2D collision)
        {
            I_ExplosionReaction objectHit = collision.gameObject.GetComponent<I_ExplosionReaction>();
            if (objectHit != null)
            {
                objectHit.HitByExplosion(this);
            }
        }

    }
}
