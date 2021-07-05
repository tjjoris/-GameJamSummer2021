using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeEscape.Bomb;

namespace FreeEscape.Damage
{
    public class RedBarrel : MonoBehaviour, I_ExplosionDamageReaction, I_TriggerExplosion
    {
        [SerializeField] private GameObject explosionPrefab;
        [SerializeField] private float explosionRadius;
        [SerializeField] private float damage;
        
        public void HitByExplosion(BombExplosion _explosion)
        {
            return;
        }

        public void TriggerExplosionRange()
        {
            GenerateExplosion();
            Destroy(gameObject);
        }

        private void GenerateExplosion()
        {
            GameObject bigExplosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            BombExplosion explosionStats = bigExplosion.GetComponent<BombExplosion>();
            explosionStats.BigExplosion = true;
            explosionStats.Damage = damage;
            
            Vector3 explosionScale = new Vector3(explosionRadius, explosionRadius, 1);
            bigExplosion.transform.localScale = explosionScale;
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
}
