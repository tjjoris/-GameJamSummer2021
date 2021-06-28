using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Damage
{
    public class RedBarrel : MonoBehaviour
    {
        [SerializeField] private GameObject explosionPrefab;
        // Start is called before the first frame update
        void Start()
        {
        
        }
        public void RedBarrelTriggered()
        {
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
