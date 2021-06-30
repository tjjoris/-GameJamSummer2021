using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreeEscape.Control
{
    public class LaunchBomb : MonoBehaviour
    {
        [SerializeField] private GameObject bombPrefab;
        private Rigidbody2D rb;
        [SerializeField] private float reverseVelocity = 100f;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        public void LaunchBombAction()
        {
            GameObject bomb = Instantiate(bombPrefab, transform.position, transform.rotation);
            Vector2 shipVelocity = rb.velocity;
            Vector2 reverseV2 = new Vector2(0, -reverseVelocity);
            bomb.GetComponent<Rigidbody2D>().AddRelativeForce(reverseV2);
            bomb.GetComponent<Rigidbody2D>().velocity = shipVelocity;
        }
    }
}
