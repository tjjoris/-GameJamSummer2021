using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Damage;

namespace FreeEscape
{
    public class BombExplosion : MonoBehaviour
    {
        [SerializeField] private bool thisIsBigExplosion;
        public bool BigExplosion { get { return thisIsBigExplosion; } set { thisIsBigExplosion = value; } }
        [SerializeField] private float _damage;
        private AudioPlayerManager audioPlayerManager;
        public float Damage { get{ return _damage; } set{ _damage = value; } }
        
        
        void Start()
        {
            audioPlayerManager = FindObjectOfType<AudioPlayerManager>();
            Destroy(gameObject, 0.2f);
            audioPlayerManager.PlayExplosion(Random.Range(0, 4));
            
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
