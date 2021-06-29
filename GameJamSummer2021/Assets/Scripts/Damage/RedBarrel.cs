using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Damage
{
    public class RedBarrel : MonoBehaviour
    {
        [SerializeField] private GameObject explosionPrefab;
        [SerializeField] private float explosionRadius;
        // Start is called before the first frame update
        void Start()
        {
        
        }
        public void RedBarrelTriggered()
        {
            GameObject bigExplosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Vector3 explosionScale = new Vector3(explosionRadius, explosionRadius, explosionRadius);
            bigExplosion.transform.localScale = explosionScale;
            Destroy(gameObject);
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
}
